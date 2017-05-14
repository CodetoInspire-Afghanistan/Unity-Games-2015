using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicStop : MonoBehaviour {
	GameObject music;
	Button btn;
	public Sprite soundOff;
	public Sprite soundOn;

	// Use this for initialization
	void Start () {
		music = GameObject.Find ("MusicPlayer") as GameObject;
		btn = GetComponent<Button> ();
		btn.onClick.AddListener (()=>{myf();});

	}
	void myf(){

		if (music.GetComponent<AudioSource> ().mute == false) {
			music.GetComponent<AudioSource> ().mute = true;
			btn.gameObject.GetComponent<Image> ().sprite = soundOff;
		} else {
			music.GetComponent<AudioSource> ().mute = false;
			btn.gameObject.GetComponent<Image> ().sprite = soundOn;

		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
