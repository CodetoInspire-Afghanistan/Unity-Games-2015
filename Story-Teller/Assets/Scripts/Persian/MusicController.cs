using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	// Use this for initialization
	private static bool IsPlay=false;

	void Awake(){
		GetComponent<AudioSource> ().Play ();
	}
	void Start () {
		
		if (IsPlay) {
			Destroy (gameObject);
		} else {
			GameObject.DontDestroyOnLoad (gameObject);
			IsPlay = true;
		}
	}
	

	void Update () {

	}

}
