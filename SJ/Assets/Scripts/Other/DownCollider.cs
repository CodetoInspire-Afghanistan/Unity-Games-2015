using UnityEngine;
using System.Collections;

public class DownCollider : MonoBehaviour {

	//for removing gameobjects when go out of the screen by trigger
    void OnTriggerEnter2D(Collider2D  other){
		Destroy (other.gameObject);
    }

	//for removing gameobjects when go out of the screen by collision
	void OnCollisionEnter2D(Collision2D col){
		Destroy (col.gameObject);
	}
}
