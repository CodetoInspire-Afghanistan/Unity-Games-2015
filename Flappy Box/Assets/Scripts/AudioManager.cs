using UnityEngine;
using System.Collections;

/// <summary>
/// Audio manager.
/// </summary>
public class AudioManager : MonoBehaviour
{
		//this method plays the audioclip of the given audio source
		public static void PlayClip (AudioSource source)
		{
				if (source == null) {
						return;
				}
				if (source.clip == null) {
						return;
				}
		
				source.Play ();
		}
	
		//this method stopes the audioclip of the given audio source
		public static void StopClip (AudioSource source)
		{
				if (source == null) {
						return;
				}
				if (source.clip == null) {
						return;
				}
		
				source.Stop ();
		}
	
		//fade-in the clip in the given audio source
		public void FadeInClip (AudioSource source, float target, float speed)
		{
				if (source == null) {
						return;
				}
		
				StopCoroutine ("FadeOutCoroutine");
				StartCoroutine (FadeInCoroutine (source, target, speed));
		}
	
		//fade-out the audioclip in the given audio source
		public void FadeOutClip (AudioSource source, float target, float speed)
		{
				if (source == null) {
						return;
				}
		
				StopCoroutine ("FadeInCoroutine");
				StartCoroutine (FadeOutCoroutine (source, target, speed));
		}
	
		private IEnumerator FadeInCoroutine (AudioSource source, float target, float speed)
		{

				while (source.volume<target) {
						source.volume += speed * Time.deltaTime;
						yield return new WaitForSeconds (0.001f);
				}
				source.volume = target;
		}
	
		private IEnumerator FadeOutCoroutine (AudioSource source, float target, float speed)
		{

				while (source.volume>target) {
						source.volume -= speed * Time.deltaTime;
						yield return new WaitForSeconds (0.001f);
				}
				source.volume = target;
		}
}