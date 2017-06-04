using UnityEngine;
using System.Collections;

public class pl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			transform.Translate (new Vector3(1,0,0));
		}


		if(Input.GetKeyDown(KeyCode.DownArrow)){
			transform.Translate (new Vector3(0,-1,0));
		}
	}
}
