using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class SoundOnOff : MonoBehaviour {
	public Sprite SoundOn;
	public Sprite SoundOff;
	GameObject music;
	Button btn;
	// Use this for initialization
	void Start () {
		music = GameObject.Find ("BackgroundMusic") as GameObject;
		btn = GetComponent<Button> ();
		btn.onClick.AddListener (()=>{myf();});

	}
	void myf(){

		if (music.GetComponent<AudioSource> ().mute == false) {
			music.GetComponent<AudioSource> ().mute = true;
			btn.gameObject.GetComponent<Image> ().sprite = SoundOff;
		} else {
			music.GetComponent<AudioSource> ().mute = false;
			btn.gameObject.GetComponent<Image> ().sprite = SoundOn;
		}
	}

}
	