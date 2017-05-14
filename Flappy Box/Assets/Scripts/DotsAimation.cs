using UnityEngine;
using System.Collections;

/// <summary>
/// Dots aimation.
/// </summary>
public class DotsAimation : MonoBehaviour
{
		public bool isRunning = true;
		public float sleepTime = 1;
		public TextMesh[] dots;
		private int currentDot = 0;
		private bool isPlaying = false;

		// Use this for initialization
		private IEnumerator StartTask ()
		{
				resetDots ();

				while (isRunning) {
						setDot (currentDot);
						currentDot++;

						if (currentDot == dots.Length + 1) {
								resetDots ();
								currentDot = 0;
						}

						yield return new WaitForSeconds (sleepTime);
				}
		}

		public void Play ()
		{
				if (!isPlaying) {
						StartCoroutine ("StartTask");
				}
		}

		public void Stop ()
		{
				isPlaying = false;
				currentDot = 0;
				resetDots ();
				StopAllCoroutines ();
		}

		private void setDot (int index)
		{
				if (dots == null) {
						return;
				}

				if (index >= 0 && index < dots.Length) {
						dots [index].text = ".";
				}
		}

		private void resetDots ()
		{
				if (dots == null) {
						return;
				}
				for (int i = 0; i < dots.Length; i++) {
						
						dots [i].text = "";
				}
		}
}
