using UnityEngine;
using System.Collections;

public class FlyJet : MonoBehaviour {

//check the collision of gameobjects with jet
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("Human")) {
			Application.LoadLevel ("Jet_Flying");

		}if (col.gameObject.CompareTag ("Shell")) {
			Destroy (gameObject);
			Application.LoadLevel ("Lose Screen");
		}
	}
}
