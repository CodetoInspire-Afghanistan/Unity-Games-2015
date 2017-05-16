using UnityEngine;
using System.Collections;

public class FireBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(){

		Destroy (gameObject);
	}
	void OnCollisionEnter2D(){
		Destroy (gameObject);
	}
}
