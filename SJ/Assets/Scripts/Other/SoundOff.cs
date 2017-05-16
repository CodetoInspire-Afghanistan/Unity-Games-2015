using UnityEngine;
using System.Collections;

public class SoundOff : MonoBehaviour {

	// Use this for initialization


    public  bool soundIsPause=false;
    public  static bool x;

	// for control the sound of game
	public void SoundStop(){
		soundIsPause = !soundIsPause;
		if (soundIsPause) {
			Camera.main.GetComponent<AudioListener> ().enabled = false;
       
            x=false;
        } else if (!soundIsPause) {
			Camera.main.GetComponent<AudioListener> ().enabled = true;
            //Camera.main.GetComponent<AudioListener> ().enabled = false;
			x=true;
		}

	}

}
