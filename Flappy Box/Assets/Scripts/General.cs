using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// General Object.
/// </summary>
public class General : MonoBehaviour
{
		public static General instance;//general instance reference
		public static AudioManager audioManagerComp;//audio manager reference
		public GameObject loadingMenu;//loading menu

		// Use this for initialization
		void Start ()
		{
				if (instance == null) {
						instance = this;
						audioManagerComp = GetComponent<AudioManager> ();
						DontDestroyOnLoad (gameObject);
				} else {
						Destroy (gameObject);
				}
		}
}