using UnityEngine;
using System.Collections;

/// <summary>
/// Implement your game events in this script
/// </summary>
public class Events : MonoBehaviour
{
		public Sprite[] musicIcons, soundsIcons;//music , sound icons references
		private const float loadingSceneSleepTime = 0.1f;//loading scene sleep time
		public Game gameComponent;//Game reference
		public Dialogs dialogsComponent;//dialogs reference

		void Start ()
		{
				GameObject gameOb = GameObject.Find ("Main");

				if (dialogsComponent == null) {
						if (gameOb != null)
								dialogsComponent = gameOb.GetComponent<Dialogs> ();
				}

				if (gameComponent == null) {
						if (gameOb != null)
								gameComponent = gameOb.GetComponent<Game> ();
				}
		}

		//on play click eventOnGameSettingPauseClick
		private void OnPlayClick (Object obj)
		{
				Debug.Log ("Play button clicked at " + Time.time);
				StartCoroutine ("LoadStagesScene");
		}

		//on stages back click event
		private void OnStagesBackClick (Object obj)
		{
				Debug.Log ("Stages Back button clicked at " + Time.time);
				StartCoroutine ("LoadMainScene");
		}

		//Game Scene event
		private void OnGameSettingPauseClick (Object obj)
		{
				Debug.Log ("Game Pause button clicked at " + Time.time);
				Game.DisableTestButtonsColliders ();
				gameComponent.OnGamePause ();
		}

		//on game pause escape event
		private void OnGamePauseEscape ()
		{
				OnGameSettingPauseClick (null);
		}

		//on game close dialog click event
		private void OnGameCloseDialogClick (Object ob)
		{
		dialogsComponent.pauseDialog.SetActive (false);

				Debug.Log ("Close dialog button clicked at " + Time.time);
				//Game.EnableTestButtonsColliders ();
				Animator dialogAnimator = dialogsComponent.pauseDialog.GetComponent<Animator> ();
				dialogAnimator.SetBool ("isFadingOut", true);
				dialogAnimator.SetBool ("isFadingIn", false);
				Game.blackScreenAnimatorComp.SetBool ("isFadingOut", true);
				Game.blackScreenAnimatorComp.SetBool ("isFadingIn", false);

				if (!Game.timerComp.isDone)
						Game.timerComp.Play ();
		GameObject.Find ("Player").GetComponent<Rigidbody2D> ().isKinematic = false;
		GameObject.Find ("World").GetComponent<Animator> ().speed = 1f;
		}

		//on game next click event
		private void OnGameNextClick (Object ob)
		{	
				Debug.Log ("Game next button button clicked at " + Time.time);
				if (Stage.selectedElementId < StorageManager.StagesStorageHelper.MaxElementsCount) {
						Stage.selectedElementId++;
						StartCoroutine ("LoadGameScene");
				} else {
						//All Stages Done,load finish scene
						Application.LoadLevel (Configuration.finishSceneName);
				}
		}

		//on game stage menu click event
		private void OnGameStagesMenuClick (Object ob)
		{
				Game.fadeInAtStagesStart = true;
				General.audioManagerComp.FadeOutClip (SFX.instance.audioSources [0], 0.5f, 0.02f);
				StartCoroutine ("LoadStagesScene");
		}

		//on game replay click event
		private void OnGameReplayClick (Object ob)
		{
				StartCoroutine ("LoadGameScene");
		}

		//on game finish google play click event
		private void OnGameFinishGooglePlayClick (Object ob)
		{
				Application.OpenURL (Configuration.googlePlayUrl);
		}

		//on facebook button click event
		private void OnFacebookButtonClick (Object obj)
		{
				Application.OpenURL (Configuration.facebookUrl);
		}

		//on main gear button click event
		private void OnMainGearButtonClick (Object obj)
		{
				StartCoroutine ("LoadSettingsScene");
		}

		//on main yes exit button click event
		private void OnMainYesExitButtonClick (Object ob)
		{
				Application.Quit ();
		}

		//on main not exit button click event
		private void OnMainNoExitButtonClick (Object ob)
		{
				Animator animator = dialogsComponent.exitDialog.GetComponent<Animator> ();
				animator.SetBool ("isFadingIn", false);
				animator.SetBool ("isFadingOut", true);
		}

		//on settings reset click event
		private void OnSettingsResetClick (Object ob)
		{
				Animator dialogAnimator = GameObject.Find ("Main").GetComponent<Animator> ();
				dialogAnimator.SetBool ("isOkFadingIn", false);
				dialogAnimator.SetBool ("isNoFadingOut", false);
				dialogAnimator.SetBool ("isYesFadingOut", false);
				dialogAnimator.SetBool ("isFadingIn", true);	
		}

		//on reset no click event
		private void OnResetNoClick (Object ob)
		{
				Animator dialogAnimator = GameObject.Find ("Main").GetComponent<Animator> ();
				dialogAnimator.SetBool ("isFadingIn", false);
				dialogAnimator.SetBool ("isNoFadingOut", true);	
		}

		//on reset yes click event
		private void OnResetYesClick (Object ob)
		{
				StorageManager.StagesDataRoot stagesDataRoot = new StorageManager.StagesDataRoot ();
				stagesDataRoot.stagesParts = StorageManager.StagesStorageHelper.GetDefaultElementsData ();
				StorageManager.StagesStorageHelper.WriteStagesData (stagesDataRoot);
				Animator dialogAnimator = GameObject.Find ("Main").GetComponent<Animator> ();
				dialogAnimator.SetBool ("isFadingIn", false);
				dialogAnimator.SetBool ("isYesFadingOut", true);	
		}

		//on reset ok click event
		private void OnResetOkClick (Object ob)
		{
				Animator dialogAnimator = GameObject.Find ("Main").GetComponent<Animator> ();
				dialogAnimator.SetBool ("isYesFadingOut", false);
				dialogAnimator.SetBool ("isOkFadingIn", true);
		}

		//on music button click event
		private void OnMusicButtonClick (Object ob)
		{
				GameObject gameob = (GameObject)ob;
				SpriteRenderer spComp = GameObject.Find ("music_icon").GetComponent<SpriteRenderer> ();
				Button btnComp = gameob.GetComponent<Button> ();
				Animator animator = gameob.GetComponent<Animator> ();

				if (btnComp.type != Button.Type.TOGGLE) {
						Debug.Log ("<i>this button</i> must be toggle");
						return;
				}

				if (btnComp.toggleStatus == Button.ToggleStatus.ON) {
						spComp.sprite = musicIcons [1];
						btnComp.toggleStatus = Button.ToggleStatus.OFF;
						animator.SetBool ("isToggleOn", false);
						animator.SetBool ("isToggleOff", true);
						SFX.instance.audioSources [0].mute = true;//mute music
				} else if (btnComp.toggleStatus == Button.ToggleStatus.OFF) {
						SFX.instance.audioSources [0].mute = false;//unmute music
						spComp.sprite = musicIcons [0];
						btnComp.toggleStatus = Button.ToggleStatus.ON;
						animator.SetBool ("isToggleOn", true);
						animator.SetBool ("isToggleOff", false);
				}
		}

		//on sound button click event
		private void OnSoundButtonClick (Object ob)
		{
				GameObject gameob = (GameObject)ob;
				SpriteRenderer spComp = GameObject.Find ("sound_icon").GetComponent<SpriteRenderer> ();
				Button btnComp = gameob.GetComponent<Button> ();
				Animator animator = gameob.GetComponent<Animator> ();
		
				if (btnComp.type != Button.Type.TOGGLE) {
						Debug.Log ("<i>this button</i> must be toggle");
						return;
				}
		
				if (btnComp.toggleStatus == Button.ToggleStatus.ON) {
						//mute sounds
						SFX.instance.audioSources [1].mute = true;
				
						spComp.sprite = soundsIcons [1];
						btnComp.toggleStatus = Button.ToggleStatus.OFF;
						animator.SetBool ("isToggleOn", false);
						animator.SetBool ("isToggleOff", true);
			
				} else if (btnComp.toggleStatus == Button.ToggleStatus.OFF) {
						//unmute sounds
						SFX.instance.audioSources [1].mute = false;

						spComp.sprite = soundsIcons [0];
						btnComp.toggleStatus = Button.ToggleStatus.ON;
						animator.SetBool ("isToggleOn", true);
						animator.SetBool ("isToggleOff", false);
				}
		}

		//on about us click event
		private void OnAboutUsClick (Object ob)
		{
				StartCoroutine ("LoadAboutUsScene");
		}

		//on back about us click event
		private void OnBackAboutUsClick (object ob)
		{
				StartCoroutine ("LoadSettingsScene");
		}

		//on settings home click event
		private void OnSettingsHomeClick (Object ob)
		{
				StartCoroutine ("LoadMainScene");
		}

		//load about us scene
		private IEnumerator LoadAboutUsScene ()
		{
				yield return new WaitForSeconds (loadingSceneSleepTime);
				Application.LoadLevel (Configuration.aboutUsSceneName);
		}

		//load main scene
		private IEnumerator LoadMainScene ()
		{
				yield return new WaitForSeconds (loadingSceneSleepTime);
				Application.LoadLevel (Configuration.mainSceneName);
		}

		//load settings scene
		private IEnumerator LoadSettingsScene ()
		{
				yield return new WaitForSeconds (loadingSceneSleepTime);
				Application.LoadLevel (Configuration.settingsSceneName);
		}

		//load game scene

	//new Scripts
		private IEnumerator LoadGameScene ()
		{
				yield return new WaitForSeconds (loadingSceneSleepTime);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("level"+Stage.selectedElementId);
 		}

		//exit from application
		private void ExitFromApplication ()
		{
				dialogsComponent.exitDialog.SetActive (true);
				Animator animator = dialogsComponent.exitDialog.GetComponent<Animator> ();
				if (animator.GetBool ("isFadingIn")) {
						animator.SetBool ("isFadingIn", false);
						animator.SetBool ("isFadingOut", true);
				} else {
						animator.SetBool ("isFadingOut", false);
						animator.SetBool ("isFadingIn", true);
				}
		}

		//load stages scene
		private IEnumerator LoadStagesScene ()
		{       
				yield return new WaitForSeconds (loadingSceneSleepTime);
				GameObject main = GameObject.Find ("Main");
				if (main != null)
						main.SetActive (false);
				GameObject.Find ("General").GetComponent<General> ().loadingMenu.SetActive (true);
				GameObject.Find ("LoadingDots").GetComponent<DotsAimation> ().Play ();
				yield return StartCoroutine ("readstages");
				Application.LoadLevel (Configuration.stagesSceneName);
		}

		//read stages
		private IEnumerator readstages ()
		{
				float startTime = Time.time;
				StorageManager.StagesStorageHelper.stagesDataRoot = StorageManager.StagesStorageHelper.ReadStagesData ();
	
				float finishTime = Time.time;
				if (Mathf.Abs (finishTime - startTime) <= 1f) {
						yield return new WaitForSeconds (1f);
				}

				yield return 0;
		}

		//Test GUI events
		private void OneStarWinTest (Object ob)
		{
				Game.DisableTestButtonsColliders ();
				Game.winStarsCount = 1;
				Game.shownDialogType = Game.DialogType.WIN;
				gameComponent.OnGameWin ();
		}

		//two stars win test
		private void TwoStarsWinTest (Object ob)
		{
				Game.DisableTestButtonsColliders ();
				Game.winStarsCount = 2;
				Game.shownDialogType = Game.DialogType.WIN;
				gameComponent.OnGameWin ();
		}

		//three stars win test
		private void ThreeStarsWinTest (Object ob)
		{
				Game.DisableTestButtonsColliders ();
				Game.winStarsCount = 3;
				Game.shownDialogType = Game.DialogType.WIN;
				gameComponent.OnGameWin ();
		}

		//you lose test
		private void YouLoseTest (Object ob)
		{
				Game.DisableTestButtonsColliders ();
				Game.shownDialogType = Game.DialogType.LOSE;
				gameComponent.OnGameLose (Game.LoseReason.WRONG_CHOICE);
		}
}