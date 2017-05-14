using UnityEngine;
using System.Collections;

/// <summary>
/// Slider Manager.
public class SliderManager : MonoBehaviour
{
		private bool isMobile;//is the current platform mobile
		private bool isDragging;//is slider dragging
		private bool isLerpingToTarget;//is lerping to a traget
		private Vector3 clickPos, clickPosInWorldSpace;
		private Vector3 obPositon;//slider position
		private Vector3 prevPos, lastPos;//mouse click previous and last position
		private GameObject clickedOb;//clicked object
		private float xOffset;//offset between slider and mouse position in the world space
		private const float sliderLimitOffset = 0.5f;
		public Camera cam;//your camera
		public Transform obTransform;//slider transform
		public Transform centerPoint;
		private int stageCount;//number of stages
		public SpriteRenderer stageNumber;//current stage number
		public SpriteRenderer[]arrows;//arrows sprite renderers
		public Sprite[] arrowIcons;//arrows sprite renderers
		public Sprite[] stagesNumber;//stage number icons
		public SliderDots sliderDotsComp;//slider dots refernces
		public Transform firstStage, lastStage;//first and last stages references
		private Vector2 firstStageInitailPos, lastStageInitailPos, sliderInitialPos;
		private bool isRunning = true;
		private bool isBorderClickIgnored;//is border click ingored or canceld
		private bool isClickedOnBorder;//is there a click on a border

		// Use this for initialization
		IEnumerator Start ()
		{
				if (cam == null) {
						cam = Camera.main;
				}
		       
				isMobile = PlatformChecker.IsAndroid () || PlatformChecker.IsIOS ();
				firstStageInitailPos = firstStage.position;
				lastStageInitailPos = lastStage.position;
				sliderInitialPos = transform.position;

				if (sliderDotsComp == null) {
						sliderDotsComp = GameObject.Find ("SliderDots").GetComponent<SliderDots> ();
				}
				
				lastPos = prevPos = Vector3.zero;
				obTransform = transform;

				if (centerPoint == null) {
						centerPoint = GameObject.Find ("Center").transform;
				}
				SetImages (1);
				stageCount = obTransform.childCount;
				yield return 0;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (!isRunning) {
						return;
				}

				if (isMobile) {
						if (Input.touchCount != 0) {
								if (Input.GetTouch (0).phase == TouchPhase.Began) {
										OnClickDown ();
								} else if (Input.GetTouch (0).phase == TouchPhase.Ended) {
										OnClickUp ();
								}
						}
				} else {
						if (Input.GetMouseButtonDown (0)) {
								OnClickDown ();
						} else if (Input.GetMouseButtonUp (0)) {
								OnClickUp ();
						}
				}
		}
         
		void FixedUpdate ()
		{
				if (!isRunning) {
						return;
				}

				if (isDragging) {

						if (isMobile) {
								clickPos = Input.GetTouch (0).position;
						} else {
								clickPos = Input.mousePosition;
						}

						clickPosInWorldSpace = cam.ScreenToWorldPoint (clickPos);
						obPositon = transform.position;
						obPositon.x = Mathf.Clamp (clickPosInWorldSpace.x - xOffset, firstStageInitailPos.x - (lastStageInitailPos.x - sliderInitialPos.x) - sliderLimitOffset, firstStageInitailPos.x + sliderLimitOffset);
						obTransform.position = obPositon;
						prevPos = lastPos;
						lastPos = obTransform.position;
						if (Vector2.Distance (lastPos, prevPos) > 0.025f) {//0.025 is the minmum distance(offset) to reset icons
								ResetIcons ();
						}
				}
		}

		//Handle Click Down
		private void OnClickDown ()
		{
				ResetIcons ();
				if (isMobile) {
						clickPos = Input.GetTouch (0).position;
				} else {
						clickPos = Input.mousePosition;
				}

				Vector3 wantedPos = Camera.main.ScreenToWorldPoint (new Vector3 (clickPos.x, clickPos.y, 0 - cam.transform.position.z));
				RaycastHit2D hit2d = Physics2D.Raycast (wantedPos, Vector2.zero);
		
				bool doDrag = false;
		
				if (hit2d.collider != null) {
						string obTag = hit2d.collider.tag;

						if (obTag == "UIButton") {
								return;
						}
						if (obTag == "NextArrow") {
								MoveToGroup (int.Parse (GetClosestGroupToCenter ().name.Split ('_') [1]) + 1);
						} else if (obTag == "PrevArrow") {
								MoveToGroup (int.Parse (GetClosestGroupToCenter ().name.Split ('_') [1]) - 1);
						} else if (obTag == "StageElement") {
								if (!hit2d.collider.gameObject.GetComponent<StageElement> ().isLocked) {
										isClickedOnBorder = true;
										isBorderClickIgnored = false;
										clickedOb = hit2d.collider.gameObject;
										clickedOb.transform.Find ("select-icon").gameObject.SetActive (true);
										AudioManager.PlayClip (SFX.instance.audioSources [1]);
								}
								doDrag = true;
				
						} else {
								doDrag = true;
						}
				} else {
						doDrag = true;
				}
		
				if (doDrag) {
						lastPos = prevPos = obTransform.position;
						StopAllCoroutines ();
						isLerpingToTarget = false;
						clickPosInWorldSpace = cam.ScreenToWorldPoint (clickPos);
						xOffset = clickPosInWorldSpace.x - obTransform.position.x;
						isDragging = true;
				}
		}
	
		//Handle Click Up
		private void OnClickUp ()
		{
				if (isDragging) {
						isDragging = false;
						isLerpingToTarget = false;
						StopAllCoroutines ();
			
						Vector3 wantedPos = Camera.main.ScreenToWorldPoint (new Vector3 (clickPos.x, clickPos.y, 0 - cam.transform.position.z));
						RaycastHit2D hit2d = Physics2D.Raycast (wantedPos, Vector2.zero);
						if (hit2d.collider != null) {
								string obTag = hit2d.collider.tag;
							
								if (obTag == "StageElement") {
										if (!isBorderClickIgnored && isClickedOnBorder) {
												StageElement stageElement = hit2d.collider.gameObject.GetComponent<StageElement> ();
												if (stageElement.id == clickedOb.GetComponent<StageElement> ().id) {
														Stage.selectedElementId = stageElement.id;//get the current clicked stage element id
														if (!stageElement.isLocked) {
																isRunning = false;
																if (Stage.selectedElementId == 1) {
																		Debug.Log ("you clicked on the first level");
																} else {
																		Debug.Log ("you clicked on level " + Stage.selectedElementId);
																}

								//
								UnityEngine.SceneManagement.SceneManager.LoadScene ("level"+Stage.selectedElementId);
																return;
														} 
												}
										}
								}
						}

						isClickedOnBorder = false;
						ResetIcons ();
						float distance = lastPos.x - prevPos.x;
						float sign = Mathf.Sign (distance);

						bool isMovedToGroup = false;
						if (Mathf.Abs (distance) >= 0.005f) {//0.01 minmum distance(offset) to move certain stage(group)
								if (sign == 1) {
										isMovedToGroup = MoveToGroup (int.Parse (GetClosestGroupToCenter ().name.Split ('_') [1]) - 1);
								} else {
										isMovedToGroup = MoveToGroup (int.Parse (GetClosestGroupToCenter ().name.Split ('_') [1]) + 1);
								}
						}
						if (!isMovedToGroup) {
								StartCoroutine ("LerpClosestToCenter");
						}
				}
		}

		//get the closest group(stage) to the center
		private Transform GetClosestGroupToCenter ()
		{
				Transform child;
				Transform closestChild;
				Vector2 v1 = new Vector2 (centerPoint.position.x, 0);
				Vector2 v2 = Vector2.zero;
				Vector3 v3 = Vector2.zero;
				closestChild = obTransform.GetChild (0);

				for (int i = 1; i < stageCount; i++) {
						child = obTransform.GetChild (i);
						v2.x = closestChild.position.x;
						v3.x = child.position.x;
						if (Vector2.Distance (v1, v2) > Vector2.Distance (v1, v3)) {
								closestChild = child;
						}
				}
				return closestChild;
		}

		//lerp the closest stage (group) to the center point
		private IEnumerator LerpClosestToCenter ()
		{
				Transform closestToCenter = GetClosestGroupToCenter ();
				SetImages (int.Parse (GetClosestGroupToCenter ().name.Split ('_') [1]));
				float xCenterOffset = closestToCenter.position.x - centerPoint.position.x;
				float tragetX = obTransform.position.x - xCenterOffset;
				isLerpingToTarget = true;
				yield return StartCoroutine (LerpToTarget (tragetX));
		}

		//lerp to a traget 
		private IEnumerator LerpToTarget (float tragetX)
		{
				float lerpSpeed = 10;
				Vector3 wantedPos = Vector3.zero;

				while (Mathf.Abs(obTransform.position.x-tragetX) >= 0.02f) {//when 0.02 or less is reached then stop
						wantedPos = obTransform.position;
						wantedPos.x = Mathf.Lerp (obTransform.position.x, tragetX, lerpSpeed * Time.deltaTime);
						obTransform.position = wantedPos;
						yield return 0;
				}
				isLerpingToTarget = false;
		}

		//Move to a group (stage)
		private bool MoveToGroup (int stageNumber)
		{
				if (isLerpingToTarget) {
						return false;
				}

				if (stageNumber >= 1 && stageNumber <= stageCount) {
						//play sfx for slide
						//SFX.instance.audioSources [1].clip = SFX.instance.slideSFX;
						//AudioManager.PlayClip (SFX.instance.audioSources [1]);
						SetImages (stageNumber);

						string groupName = "Stage_" + stageNumber;
						float xTargetOffset = GameObject.Find (groupName).transform.position.x - centerPoint.position.x;
						isLerpingToTarget = true;
						StartCoroutine (LerpToTarget (obTransform.position.x - xTargetOffset));
						return true;
				}
				return false;
		}

		//Set arrows icons(alpha) , stage number
		private void SetImages (int groupNumber)
		{
				Color tempColor;
				if (groupNumber == 1) {
						//Setting Arrows Images
						tempColor = arrows [0].color;
						tempColor.a = 100 / 255.0f;
						arrows [0].color = tempColor;
			
						tempColor = arrows [1].color;
						tempColor.a = 1;
						arrows [1].color = tempColor;

				} else if (groupNumber == stageCount) {
						//Setting Arrows Images
			
						tempColor = arrows [0].color;
						tempColor.a = 1;
						arrows [0].color = tempColor;
			
						tempColor = arrows [1].color;
						tempColor.a = 100 / 255.0f;
						arrows [1].color = tempColor;

				} else {
						//Setting Arrows Images
						tempColor = arrows [0].color;
						tempColor.a = 1;
						arrows [0].color = tempColor;
			
						tempColor = arrows [1].color;
						tempColor.a = 1;
						arrows [1].color = tempColor;
				}

				stageNumber.sprite = stagesNumber [groupNumber - 1];
				sliderDotsComp.setDot (groupNumber - 1);
		         
		}

		//Reset Icons To Default
		private void ResetIcons ()
		{
				if (clickedOb == null) {
						return;
				}
				if (clickedOb.tag == "StageElement") {
						isBorderClickIgnored = true;
						clickedOb.transform.Find ("select-icon").gameObject.SetActive (false);

				}
				clickedOb = null;
		}
}