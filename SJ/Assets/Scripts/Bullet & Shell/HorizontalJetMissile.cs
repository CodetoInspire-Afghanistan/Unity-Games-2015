using UnityEngine;
using System.Collections;

public class HorizontalJetMissile : MonoBehaviour {


	public AudioClip ExplosionSound;

	void OnCollisionEnter2D(Collision2D col){
		
		Destroy (gameObject);
		AudioSource.PlayClipAtPoint (ExplosionSound,transform.position,0.5f);
		if (col.gameObject.CompareTag ("Player") || col.gameObject.CompareTag("Human")) {
			Destroy (col.gameObject);
			Application.LoadLevel ("Lose Screen");

		}
	}

}
