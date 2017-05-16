using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {



	void OnTriggerEnter2D(Collider2D col){
	Destroy (gameObject);
}
	void OnCollisionEnter2D(Collision2D col){
		Destroy (gameObject);

	}
}
