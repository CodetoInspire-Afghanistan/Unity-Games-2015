using UnityEngine;
using System.Collections;

/// <summary>
/// Animation events.
/// [put your animation events here]
/// </summary>
public class AnimationEvents : MonoBehaviour
{
		public WinStarsManager winStarManagerComp;
		public GameObject exitDialog;
		private static int starNumber = 0;

		// Use this for initialization
		void Start ()
		{
				starNumber = 0;
		}

		private void PauseDialogFadeOut ()
		{
				GameObject.Find ("pause_button").GetComponent<Collider2D> ().enabled = true;
		}

		private void WinDialogEvent ()
		{
				winStarManagerComp.PrepareStars (Game.winStarsCount);
		}

		private void CameraShakingStart ()
		{
				Camera.main.GetComponent<Animator> ().SetBool ("isRunning", true);
				SFX.instance.audioSources [2].clip = SFX.instance.starsSFX [starNumber];
				SFX.instance.audioSources [2].Play ();
				starNumber++;
				if (starNumber == SFX.instance.starsSFX.Length) {
						starNumber = 0;
				}
		}

		private void CameraShakingEnd ()
		{
				Camera.main.GetComponent<Animator> ().SetBool ("isRunning", false);
		}

		private void ExitDialogStart ()
		{
				GameObject blackScreen = GameObject.Find ("blackScreen");
				blackScreen.GetComponent<SpriteRenderer> ().enabled = true;

				GameObject.Find ("playButton").GetComponent<Collider2D> ().enabled = false;
				GameObject.Find ("menuButton").GetComponent<Collider2D> ().enabled = false;
				GameObject.Find ("facebookButton").GetComponent<Collider2D> ().enabled = false;
		}

		private void ExitDialogEnd ()
		{
				GameObject blackScreen = GameObject.Find ("blackScreen");
				blackScreen.GetComponent<SpriteRenderer> ().enabled = false;
				exitDialog.SetActive (false);
				GameObject.Find ("playButton").GetComponent<Collider2D> ().enabled = true;
				GameObject.Find ("menuButton").GetComponent<Collider2D> ().enabled = true;
				GameObject.Find ("facebookButton").GetComponent<Collider2D> ().enabled = true;
		}
}
