using UnityEngine;
using System.Collections;

public class marerial : MonoBehaviour {
 
	int first=0;
	int end=3;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}


	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "shell") {
			this.gameObject.SetActive (false);
		}
	}
	 

}
