using UnityEngine;
using System.Collections;

/// <summary>
/// This script handles user inputs like buttons
/// </summary>
[RequireComponent(typeof(Events))]
public class InputsHandler : MonoBehaviour
{
	public Camera cam;
	private bool isMobile;
	private bool mouseClickStarted;
	private GameObject lastClickedBtn;
	public GameObject[] buttons;
	public GameObject eventOb;
	public string escapeEventName = "";
	
	// Use this for initialization
	void Start ()
	{
		isMobile = PlatformChecker.IsAndroid () || PlatformChecker.IsIOS ();
		
		if (cam == null) {
			cam = Camera.main;
		}
		
		if (eventOb == null) {
			eventOb = cam.gameObject;
		}
		
		if (buttons.Length == 0) {
			buttons = GameObject.FindGameObjectsWithTag ("UIButton");
		}
		
		Events eventsComp = GetComponent<Events> ();
		if (eventsComp == null) {//add Events component if it's missed
			gameObject.AddComponent<Events> ();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!string.IsNullOrEmpty (escapeEventName)) {
				eventOb.SendMessage (escapeEventName);
			}
		}
		
		if (isMobile) {
			OnScreenTouch ();
		} else {
			OnMouseClick ();
		}
	}
	
	//Raycast Touch Input
	private void OnScreenTouch ()
	{
		if (Input.touchCount == 0) {
			return;
		}
		
		Touch touch = Input.GetTouch (0);
		if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) {//Touch Moved or Touch Began
			Vector3 touchPos = touch.position;
			touchPos.z = 0 - cam.transform.position.z;
			Vector3 wantedPos = cam.ScreenToWorldPoint (touchPos);
			bool isTouchBegan = true;
			
			if (touch.phase == TouchPhase.Moved) {
				isTouchBegan = false;
			}
			RaycastHit2D hit2d = Physics2D.Raycast (wantedPos, Vector3.zero);
			if (hit2d.collider != null) { // if touch hits a button
				ScreenClickHandle (hit2d.collider.gameObject, isTouchBegan);
			} else { //if current ray does not touch any button
				ScreenClickHandle (null, isTouchBegan);
			}
		} else if (touch.phase == TouchPhase.Ended) {//Touch Up
			ScreenClickEndedHandle ();
		}
	}
	
	//Raycast Mouse Input
	private void OnMouseClick ()
	{
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 0 - cam.transform.position.z;
		Vector3 wantedPos = cam.ScreenToWorldPoint (mousePos);
		RaycastHit2D hit2d = Physics2D.Raycast (wantedPos, Vector2.zero);
		
		if (hit2d.collider != null) {
			if (Input.GetMouseButtonDown (0)) {
				ScreenClickHandle (hit2d.collider.gameObject, true);
				mouseClickStarted = true;
			} else if (mouseClickStarted) {
				ScreenClickHandle (hit2d.collider.gameObject, false);
			}  
		} else {
			ScreenClickHandle (null, false);
		}
		if (Input.GetMouseButtonUp (0)) {
			
			if (mouseClickStarted) {
				ScreenClickEndedHandle ();
				mouseClickStarted = false;
			}
		}
	}
	
	//General Handling
	private void ScreenClickHandle (GameObject ob, bool isTouchBegain)
	{
		string objname = "";// name of button that ray hit it
		
		if (ob != null)
			objname = ob.name;
		
		foreach (GameObject btn in buttons) {
			
			if (btn == null) {
				continue;
			}
			Button btnComp = btn.GetComponent<Button> ();
			if (btnComp == null) {
				continue;
			}
			
			if (objname == btn.name) {
				if (!btnComp.isBegan) {
					btnComp.isBegan = true;
					lastClickedBtn = btn;
					if (btnComp.hoverIcon != null)
						btnComp.spriteRendererComp.sprite = btnComp.hoverIcon;
					
					if (btnComp.clickReleaseSFx != null) {
						SFX.instance.audioSources [1].clip = btnComp.clickReleaseSFx;//play sfx on click or on touch began
						AudioManager.PlayClip (SFX.instance.audioSources [1]);
					}
				}
			} else {
				if (!isTouchBegain && btnComp.isBegan) {
					lastClickedBtn = null;
					btnComp.isBegan = false;
					if (btnComp.normalIcon != null)
						btnComp.spriteRendererComp.sprite = btnComp.normalIcon;
				}
			}
		}
	}
	
	
	//Relaese Handling
	private void ScreenClickEndedHandle ()
	{
		if (lastClickedBtn == null) {
			return;
		}
		
		Button btnComp = lastClickedBtn.GetComponent<Button> ();
		if (btnComp == null) {
			return;
		}
		
		btnComp.isBegan = false;
		
		if (btnComp.resetIconOnRelease) {
			if (btnComp.normalIcon != null)
				btnComp.spriteRendererComp.sprite = btnComp.normalIcon;
		}
		
		if (!string.IsNullOrEmpty (btnComp.message)) {
			eventOb.SendMessage (btnComp.message, btnComp.messageObject);//call the given method which is inside Events.Cs
		} else {
			Debug.LogWarning ("empty message on <i>" + lastClickedBtn.name + "</i>click");//you missed to add event name
		}
		
		lastClickedBtn = null;
	}
}