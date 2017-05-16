using UnityEngine;
using System.Collections;

public class MusicPlay : MonoBehaviour {

	static bool musicAlreadyPlayed = false;

	public static AudioSource music;
	public  AudioClip allLevels;
	public AudioClip lose;
	public AudioClip win;


	// Use this for initialization
	void Start () {
		if (musicAlreadyPlayed) {
			Destroy (gameObject);
		} else {
			musicAlreadyPlayed = true;
			AudioSource.DontDestroyOnLoad (gameObject);

		}
	}

	//play different musics in different levels
	void  OnLevelWasLoaded(int Level){
		music = GetComponent<AudioSource> ();
		if(ReTry.isStarted){
			GameObject mus = GameObject.Find ("MusicsPlay") as GameObject;
			mus.GetComponent<AudioSource> ().clip=allLevels;
			mus.GetComponent<AudioSource> ().Play ();
			ReTry.isStarted = false;
		}

		if (Level != 28) {
			music.clip = allLevels;
			music.loop = true;
		}
		if (Level == 28) {
			music.Stop ();
			music.clip = lose;
			music.Play ();
			music.loop = false;
		}
		if (Level == 29) {
			music.Stop ();
			music.clip = win;
			music.Play ();
			music.loop = true;
		}
	}
}
