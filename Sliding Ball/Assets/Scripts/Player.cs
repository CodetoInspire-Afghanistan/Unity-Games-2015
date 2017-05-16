using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	[SerializeField]
	private GameObject panelTime;

	private bool fading;
	private Color alphaColor;

	private Vector3 position;

	[SerializeField]
	private float speed;

	private bool deActiveMove;

	private Animator myAnimat;

	private AudioSource musicWin;

	GameObject mus;

	// Use this for initialization
	void Start () {
		musicWin = GetComponent<AudioSource> ();
		deActiveMove = true;
		fading = false;
		alphaColor = GameObject.FindObjectOfType<Renderer> ().material.color;
		myAnimat = GameObject.FindObjectOfType<Animator> ();
		mus = GameObject.Find ("MusicsPlay") as GameObject;
	}


	// Update is called once per frame
	void Update () {
		InvokeRepeating ("ActiveFade",0,9f);
		position = transform.position;
		position.x = Mathf.Clamp (position.x, -2.53f, 2.52f);
		position.y = Mathf.Clamp (position.y, -4.65f, 3.95f);
		transform.position = position;
		Move ();
		ActiveTouch ();
	}

	//fade the player ball 
	void ActiveFade(){
		if (fading) {
			if (alphaColor.a > 0) {
				alphaColor.a -= Time.deltaTime;
				GetComponent<Renderer> ().material.color = alphaColor;
				if(alphaColor.a < 0) {
					panelTime.gameObject.SetActive (true);
					Time.timeScale = 0;
						musicWin.Stop ();
				}
			}
		}
	}

	//for moving player ball
	void Move(){
		if(deActiveMove == false){
			float inputX = Input.acceleration.x;
			float inputY = Input.acceleration.y;
			transform.Translate (inputX * Time.deltaTime * speed, inputY * Time.deltaTime * speed, 0);
	    }
	}

	//useable game for touch
	void ActiveTouch(){
		if (Input.touchCount >0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			deActiveMove = false;
	}
	}


	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Obstacle") {
			SceneManager.LoadScene ("LoseScene");
		}
		if (other.gameObject.tag == "last") {
			SceneManager.LoadScene ("WinScene");
		}
		if(other.gameObject.tag == "Main"){
				musicWin.Play ();
			fading = true;
			deActiveMove = true;
		}
	}


	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "hole") {
			Vector3 pos = transform.position;
			pos = col.transform.position;
			transform.position = pos;
			myAnimat.SetTrigger ("fall");
			deActiveMove = true;
		}
	}
}
