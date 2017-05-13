using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buttonScript : MonoBehaviour {
	GameObject music;
	Button button;
	// Use this for initialization
	void Start () {
		music = GameObject.Find ("music Player") as GameObject;
		button = GetComponent<Button> ();
		button.onClick.AddListener (()=>{playingMusic();});

	}
	//when touch on gameobject music will have  played.
	void playingMusic(){

		if (music.GetComponent<AudioSource> ().mute == false) {
			music.GetComponent<AudioSource> ().mute = true;
		} else {
			music.GetComponent<AudioSource> ().mute = false;
		}
	}

}
