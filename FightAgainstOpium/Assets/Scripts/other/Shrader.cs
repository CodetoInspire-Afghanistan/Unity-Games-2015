using UnityEngine;
using System.Collections;

public class Shrader : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		Destroy (col.gameObject);

	}
	void OnCollisionEnter2D(Collision2D coll){
		Destroy (coll.gameObject);
	}
}
