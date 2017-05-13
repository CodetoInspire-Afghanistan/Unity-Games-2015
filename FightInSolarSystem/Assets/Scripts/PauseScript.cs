using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {
    public bool paused;

 	void Start () {
	paused=false;
	}
	
 	void Update () {
	}

    public void pause(){
        paused=!paused;
		if (paused){
  		  Time.timeScale=0;
		}
		else if (!paused){
		Time.timeScale=1;
       }

    }

}
