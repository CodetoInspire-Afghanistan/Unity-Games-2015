using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {
	
	// Use this for initialization
	private static bool y = false;
	private  AudioSource myMusic;
	
	public AudioClip A;
	public AudioClip B;
	public AudioClip C;
	
	void Awake(){
		
	}
	
	void Start () {
		if (y) {
			Destroy (gameObject);
		} else {
			
			y = true;
			DontDestroyOnLoad (gameObject);
			myMusic = this.GetComponent<AudioSource>();
			GameObject.DontDestroyOnLoad(myMusic);
			myMusic.clip = B;
			myMusic.Play ();

			//myMusic.loop = true;
		}
	}
	void OnLevelWasLoaded(int Level){
		//myMusic = this.GetComponent<AudioSource>();
		
		//print (Level);
		//myMusic.Stop ();
		if (Level == 0) {
			myMusic.clip = A;
			myMusic.Play ();

		} else if (Level == 1) {
			myMusic.clip = C;
			myMusic.Play ();

			//} else {
			//print("Ehsa");
		//}
		myMusic.loop = true;
	}
	
}
}
