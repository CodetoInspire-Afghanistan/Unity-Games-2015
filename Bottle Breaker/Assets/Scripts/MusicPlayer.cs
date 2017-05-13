using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static bool musicIsPlaying = false;
	// Use this for initialization
	void Start () {
		if (musicIsPlaying) {
			Destroy (gameObject);
		} else {
			GameObject.DontDestroyOnLoad (this.gameObject);
			musicIsPlaying =true;
		}
	}

}
