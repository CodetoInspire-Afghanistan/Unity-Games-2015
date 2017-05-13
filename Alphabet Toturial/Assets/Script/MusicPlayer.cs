using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static bool musicAlreadyExist = false;


		private static AudioSource Music;
	//Define AudioClip for each level
		public AudioClip level1;
		public AudioClip level2;
		public AudioClip level3;
		public AudioClip level4;
		public AudioClip AboutUs;
		public AudioClip start;
		public AudioClip Win;
	
	
		// Use this for initialization
	//if music is already exit for previous secene prives it will destory
		void Start () {
		
			if (musicAlreadyExist) {
	
				Destroy(gameObject);
			} 

		}
	


		void OnLevelWasLoaded(int Level){
		// get the audio and the play the audio for each level 
			Music = this.GetComponent<AudioSource>();


			if (Level==1){
				Music.clip = level1;
				Music.Play();
				Music.loop = true;
	
			}
	
			if (Level ==2){
				Music.clip = level2;
				Music.Play();
				Music.loop = true;
	
	
			}
			if (Level == 3){
				Music.clip = level3;
				Music.Play();
				Music.loop = true;
	
			}
	
	
			if (Level == 4){
				Music.clip =level4;
				Music.Play();
				Music.loop = true;
			}
	    
			
			if (Level == 5){
				Music.clip =Win ;
				Music.Play();
				Music.loop = true;
			}
			if (Level == 6){
			Music.clip =AboutUs ;
				Music.Play();
				Music.loop = true;
			}
		}
}
