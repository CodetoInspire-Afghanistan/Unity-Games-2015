using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

/// <summary>
/// Game Script.
/// </summary>
public class Game : MonoBehaviour
{       
		public static int maxWinCutCount = 3;//max win cut count
		public static DialogType shownDialogType = DialogType.NONE;//current shown dialog
		public static Timer timerComp;//timer component reference
		public static int winStarsCount = 0;//current win stars count
		public static GameObject topGroup;//top group reference
		public static bool fadeInAtStagesStart = false;
		public static Animator blackScreenAnimatorComp;//black screen animator
		public Dialogs dialogsComponent;//dialogs component
		public TextMesh gameLevelTextMeshComp;//game level text mesh component
		public static Collider2D pauseButtonCollider;//pause button collider
		public GameObject cloudsContainer;//clouds container
		public Camera cam;//camera reference

		IEnumerator Start ()
		{
				//setting up references
				if (cam == null) {
						cam = Camera.main;
				}

				if (pauseButtonCollider == null) {
						pauseButtonCollider = GameObject.Find ("pause_button").GetComponent<Collider2D> ();
				}

				if (timerComp == null) {
						timerComp = GetComponent<Timer> ();
				}

				if (blackScreenAnimatorComp == null) {
						blackScreenAnimatorComp = GameObject.Find ("blackScreen").GetComponent<Animator> ();
				}

				if (topGroup == null) {
						topGroup = GameObject.Find ("TopGroup");
				}

				if (gameLevelTextMeshComp == null) {
						gameLevelTextMeshComp = GameObject.Find ("levelnumber").GetComponent<TextMesh> ();
				}

				if (dialogsComponent == null) {
						dialogsComponent = GetComponent<Dialogs> ();
				}

				winStarsCount = 0;
				gameLevelTextMeshComp.text = "" + Stage.selectedElementId;

				try {
						LoadLevelData ();//load you level data
				} catch (Exception e) {
						Debug.Log (e.Message);
				}


				pauseButtonCollider.enabled = true;
				shownDialogType = DialogType.NONE;
				timerComp.Play ();
				yield return 0;
		}

		private void LoadLevelData ()
		{
				//Load your level data here
				Debug.Log ("Loading Level Data");
		}

		//on game win
		public void OnGameWin ()
		{
				try {
						if (dialogsComponent.winDialog.activeSelf || dialogsComponent.loseDialog.activeSelf || shownDialogType != Game.DialogType.WIN) {
								return;
						}
			       GameObject.Find ("Player").GetComponent<Rigidbody2D> ().isKinematic = true;
			       GameObject.Find ("World").GetComponent<Animator> ().speed = 0f;
						pauseButtonCollider.enabled = false;
						General.audioManagerComp.FadeOutClip (SFX.instance.audioSources [0], 0.5f, 0.1f);
						blackScreenAnimatorComp.SetBool ("isFadingOut", false);
						blackScreenAnimatorComp.SetBool ("isFadingIn", true);
						dialogsComponent.winDialog.SetActive (true);
						Animator winDialogAnimatorComp = dialogsComponent.winDialog.GetComponent<Animator> ();
						winDialogAnimatorComp.SetBool ("isFadingOut", false);
						winDialogAnimatorComp.SetBool ("isFadingIn", true);
					
						if (winStarsCount >= 1 && winStarsCount <= 3) {
								//Save new level data To file
								StorageManager.StagesDataRoot stagesDataRoot = StorageManager.StagesStorageHelper.stagesDataRoot;

								if (stagesDataRoot == null) {
										Debug.Log ("stagesDataRoot is undefined");
										return;
								}
								if (stagesDataRoot.stagesParts == null) {
										Debug.Log ("stagesDataRoot.stagesParts is undefined");
										return;
								}
		
								StorageManager.StagePart currentStagePart = StorageManager.StagesStorageHelper.GetStagePartById (Stage.selectedElementId, stagesDataRoot.stagesParts);
		
								if (currentStagePart == null) {
										Debug.Log ("currentStagePart is undefined");
										return;
								}
								if (Stage.selectedElementId + 1 <= StorageManager.StagesStorageHelper.MaxElementsCount) {
										StorageManager.StagePart nextStagePart = StorageManager.StagesStorageHelper.GetStagePartById (Stage.selectedElementId + 1, stagesDataRoot.stagesParts);
										nextStagePart.isLocked = false;
								}
		
								if (currentStagePart != null) {
										currentStagePart.isLocked = false;
										currentStagePart.starLevel = Game.winStarsCount;
										StorageManager.StagesStorageHelper.WriteStagesData (stagesDataRoot);
								} else {
										Debug.Log ("currentStagePart is undefined");
								}
						}
				} catch (Exception ex) {
						Debug.LogError (ex.Message);
				}
		}

		//on game lose
		public void OnGameLose (LoseReason loseReason)
		{
				if (dialogsComponent.winDialog.activeSelf || dialogsComponent.loseDialog.activeSelf || shownDialogType != Game.DialogType.LOSE) {
						return;
				}
	
				General.audioManagerComp.FadeOutClip (SFX.instance.audioSources [0], 5, 0.01f);
				SFX.instance.audioSources [2].clip = SFX.instance.loseSFX;
				SFX.instance.audioSources [2].Play ();

				try {
						pauseButtonCollider.enabled = false;
						blackScreenAnimatorComp.SetBool ("isFadingOut", false);
						blackScreenAnimatorComp.SetBool ("isFadingIn", true);
						dialogsComponent.loseDialog.SetActive (true);
                
						TextMesh dialogMessage = dialogsComponent.loseDialog.transform.Find ("text").GetComponent<TextMesh> ();
						Animator loseDialogAnimatorComp = dialogsComponent.loseDialog.GetComponent<Animator> ();
						loseDialogAnimatorComp.SetBool ("isFadingOut", false);
						loseDialogAnimatorComp.SetBool ("isFadingIn", true);

						if (loseReason == LoseReason.WRONG_CHOICE) {
								dialogMessage.text = "Your Choice is wrong !";//put your reason here
						} else if (loseReason == LoseReason.TIMEOUT) {
								dialogMessage.text = "Timeout";//time-out reason
						}
						
				} catch (Exception ex) {
						Debug.LogError (ex.Message);
				}
		}

		//on game pause
		public void OnGamePause ()
		{
				if (!(shownDialogType == DialogType.NONE || shownDialogType == Game.DialogType.PAUSE)) {
						return;
				}

				pauseButtonCollider.enabled = true;
				dialogsComponent.pauseDialog.SetActive (true);
				Animator dialogAnimator = dialogsComponent.pauseDialog.GetComponent<Animator> ();
		
				if (dialogAnimator.GetBool ("isFadingIn")) {
						dialogAnimator.SetBool ("isFadingIn", false);
						dialogAnimator.SetBool ("isFadingOut", true);
						blackScreenAnimatorComp.SetBool ("isFadingIn", false);
						blackScreenAnimatorComp.SetBool ("isFadingOut", true);
						if (!timerComp.isDone)
								timerComp.Play ();
			
						shownDialogType = Game.DialogType.NONE;
					
				} else {
						SFX.instance.audioSources [1].clip = SFX.instance.pauseSFX;
						AudioManager.PlayClip (SFX.instance.audioSources [1]);
						dialogAnimator.SetBool ("isFadingOut", false);
						dialogAnimator.SetBool ("isFadingIn", true);
						blackScreenAnimatorComp.SetBool ("isFadingOut", false);
						blackScreenAnimatorComp.SetBool ("isFadingIn", true);
						if (!timerComp.isDone)
								timerComp.Pause ();
						GameObject.Find ("Player").GetComponent<Rigidbody2D> ().isKinematic = true;
						GameObject.Find ("World").GetComponent<Animator> ().speed = 0f;
						shownDialogType = Game.DialogType.PAUSE;
				}
		}

		//on time out
		public void OnTimeOut ()
		{
				DisableTestButtonsColliders ();
				shownDialogType = DialogType.LOSE;
				OnGameLose (LoseReason.TIMEOUT);
		}

		//time to stars number
		public static  void TimeToStarsLevel ()
		{
				int stars = 0;
				int ctime = int.Parse (timerComp.CTime.Split (':') [1]);
				if (ctime >= 25) {
						stars = 3;
				} else if (ctime >= 15 && ctime < 25) {
						stars = 2;
				} else if (ctime >= 0 && ctime < 15) {
						stars = 1;
				}
				winStarsCount = stars;
		}

		
	
		public static void DisableTestButtonsColliders ()
		{
				//disable test buttons colliders
			//	BoxCollider2D [] testColliders = GameObject.Find ("TestGUI").GetComponentsInChildren<BoxCollider2D> ();
		//		foreach (Collider2D col in testColliders) {
		//				col.enabled = false;
		//		}
		}

		public enum DialogType
		{
				WIN,
				PAUSE,
				LOSE,
				NONE
		}

		public enum LoseReason
		{
				TIMEOUT,
				WRONG_CHOICE
		}
}