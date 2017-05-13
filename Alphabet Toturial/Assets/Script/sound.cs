using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class sound : MonoBehaviour {

	GameObject music;
	Button btn;
	// Use this for initialization
	void Start () {
		music = GameObject.Find ("Music") as GameObject;
		btn = GetComponent<Button> ();
		btn.onClick.AddListener (()=>{Musiclistener();});

	}
	void Musiclistener(){

		if (music.GetComponent<AudioSource> ().mute == false) {
			music.GetComponent<AudioSource> ().mute = true;
		} else {
			music.GetComponent<AudioSource> ().mute = false;
		}
	}

}
