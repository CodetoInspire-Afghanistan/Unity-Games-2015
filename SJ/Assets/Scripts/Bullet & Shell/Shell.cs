using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	void OnCollisionEnter2D(Collision2D col){

		Destroy (gameObject);
		Destroy (col.gameObject);

	}
}
