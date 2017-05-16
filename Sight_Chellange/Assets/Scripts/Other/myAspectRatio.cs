using UnityEngine;
using System.Collections;

public class myAspectRatio : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(Screen.fullScreen || Camera.main.aspect!=1){
			Screen.SetResolution (800,600,false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Screen.fullScreen || Camera.main.aspect!=1){
			Screen.SetResolution (800,600,false);
		}
	}
}
