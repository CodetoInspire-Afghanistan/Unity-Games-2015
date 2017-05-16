using UnityEngine;
using System.Collections;

/// <summary>
/// About us controller.
/// </summary>
public class AboutUsController : MonoBehaviour
{
		public Transform slider;//slider reference
		private bool isScreenClickFound;
		private bool isMobile;
		private bool isAutoSlidingRunning = true;
		private bool isMouseClickDown;//when a click down on the screen
		private bool touchBegan, touchMoved, touchEnded;
		public float autoSlideSpeed = 1;
		public float clickSlideSpeed = 1;
		public float minPos, maxPos;
		private float offset;//offset between click y-position and slider y-position
		private Vector2 clickPos;//click position in the world space
		private Button backButtonComp;
		public Camera cam;//camera reference

		// Use this for initialization
		void Start ()
		{
				isMobile = (PlatformChecker.IsAndroid () || PlatformChecker.IsIOS ());
				backButtonComp = GameObject.Find ("back_button").GetComponent<Button> ();

				if (slider == null) {
						slider = GameObject.Find ("Main/Content/slider").transform;
				}
				if (cam == null) {
						cam = Camera.main;
				}
				StartCoroutine ("AutoSliding");
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (isMobile) {//if current platform is mobile

						if (Input.touchCount != 0) {
								Touch touch = Input.GetTouch (0);//get the first touch

								touchBegan = (touch.phase == TouchPhase.Began ? true : false);
								touchMoved = (touch.phase == TouchPhase.Moved ? true : false);
								touchEnded = (touch.phase == TouchPhase.Ended ? true : false);

								if (touchBegan || touchMoved) {

										if (!backButtonComp.isBegan) {
												clickPos = cam.ScreenToWorldPoint (touch.position);//get the first touch position
										
												if (touchBegan) {
														isScreenClickFound = true;
														offset = clickPos.y - slider.position.y;//calcuate the offset
														StopCoroutine ("ClickRelease");
												}
										}
								} else if (touchEnded) {
										isScreenClickFound = false;//reset this flag
								}
						}
				} else {
						if (Input.GetMouseButtonDown (0)) {
								if (!backButtonComp.isBegan) {
										StopCoroutine ("ClickRelease");//stop ClickRelease Coroutine
										isMouseClickDown = true;
										isScreenClickFound = true;
										clickPos = cam.ScreenToWorldPoint (Input.mousePosition);//get the current mouse position
										offset = clickPos.y - slider.position.y;//calculate the offset
								}
						} else if (Input.GetMouseButtonUp (0)) {
								isScreenClickFound = false;
								isMouseClickDown = false;
								//StartCoroutine ("ClickRelease");
						}

						if (isMouseClickDown) {
								clickPos = cam.ScreenToWorldPoint (Input.mousePosition);//get the current mouse position
						}
				}

				if (isScreenClickFound) {
						TargetSliding (clickPos.y);
				}
		}

		//Auto Slide
		private IEnumerator AutoSliding ()
		{
				Vector3 sliderPos;

				while (isAutoSlidingRunning) {
						if (!isScreenClickFound) {
								slider.Translate (new Vector3 (0, autoSlideSpeed * Time.deltaTime, 0));
								sliderPos = slider.position;
								if (sliderPos.y > maxPos) {
										sliderPos.y = minPos;
										slider.position = sliderPos;
								} else if (sliderPos.y < minPos) {
										sliderPos.y = maxPos;
										slider.position = sliderPos;
								}
						}
						yield return 0;
				}
		}

		//move slider to the give traget
		private void TargetSliding (float target)
		{
				Vector3 sliderPos = slider.position;

				float y = Mathf.Lerp (sliderPos.y, target - offset, Time.deltaTime * clickSlideSpeed);

				if (y > maxPos) {
						y = minPos;
						offset = target - minPos;
				} else if (y < minPos) {
						y = maxPos;
						offset = target - maxPos;
				}

				sliderPos.y = y;
				slider.position = sliderPos;
		}

		//On click release
		private IEnumerator ClickRelease ()
		{
				Debug.Log ("Click Relesed");
				yield return 0;
		}
}