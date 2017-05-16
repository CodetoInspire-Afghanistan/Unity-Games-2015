using UnityEngine;
using System.Collections;

public class LevelsMusic : MonoBehaviour {

	static bool musicAlreadyExist = false;


	// Use this for initialization
	void Start () {
		
		if (musicAlreadyExist) {
			Destroy (gameObject);
			print ("game object destroyed");
		} else {
			AudioSource.DontDestroyOnLoad (this.gameObject);
			musicAlreadyExist = true;
		}
	}

}
