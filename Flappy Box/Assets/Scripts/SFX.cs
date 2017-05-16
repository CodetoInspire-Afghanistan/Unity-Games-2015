using UnityEngine;
using System.Collections;

/// <summary>
/// You can store SFX refernces in this script
/// </summary>
/// 
public class SFX : MonoBehaviour
{
		public AudioClip[] starsSFX;
		public AudioClip loseSFX;
		public AudioClip pauseSFX;
		public AudioSource[] audioSources;
		public static SFX instance;//static instance

		// Use this for initialization
		void Start ()
		{
				if (instance == null) {
						instance = this;
						audioSources = GetComponents<AudioSource> ();
				}
		}
}