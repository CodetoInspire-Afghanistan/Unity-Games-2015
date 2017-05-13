using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static bool musicAlreadyExist = false;

	private static AudioSource Music;
	public AudioClip Game;
	public AudioClip Game1;
	public AudioClip Start1;
	public AudioClip Win;
	public AudioClip Loss;
	public AudioClip Celebrate;
	// Use this for initialization
	void Start () {
		if (musicAlreadyExist) {
			Destroy(gameObject);
		} else{
			musicAlreadyExist = true;
		AudioSource.DontDestroyOnLoad(gameObject);

			Music = this.GetComponent<AudioSource>();
			GameObject.DontDestroyOnLoad(Music);

			Music.Play();
			Music.clip = Game;
			Music.loop = true;
	}
	}

	void OnLevelWasLoaded(int Level){

		Music = this.GetComponent<AudioSource>();
		if (Level ==6 || Level==7 || Level ==8 || Level==10 || Level==11 || Level==12 || Level==14 ||
		    Level==15 || Level==16 || Level==18){
			Music.clip = Game1;
			Music.Play();
			Music.loop = true;

		}
		if (Level==2 || Level ==3 || Level==4 || Level==5){
			Music.clip = Start1;
			Music.Play();
			Music.loop = true;
		
		}
		if (Level ==9 || Level==13 || Level ==17 || Level==19){
			Music.clip = Win;
			Music.Play();
			Music.loop = true;
			
		}
		if (Level == 20){
			Music.clip = Loss;
			Music.Play();
			Music.loop = true;
			
		}
		if (Level == 1){
			Music.clip = Celebrate;
			Music.Play();
			Music.loop = true;

		}
		if (Level == 0){
			Music.clip = Game;
			Music.Play();
			Music.loop = true;
			
			
		}

	}
	
	// Update is called once per frame
	void Update () {



	}
}
