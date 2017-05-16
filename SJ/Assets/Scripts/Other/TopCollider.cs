using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TopCollider : MonoBehaviour {


	//for deleting gameobjects when collision with another gameobject
	void OnCollisionEnter2D(Collision2D col){
		
		if ((col.gameObject.CompareTag ("RedBullet")) || 
			(col.gameObject.CompareTag ("BrownBullet")) ||
			(col.gameObject.CompareTag ("BlackBullet")) ||
			(col.gameObject.CompareTag ("PlayerLaser")) ) {
			Destroy (col.gameObject);
		}


	}
}
