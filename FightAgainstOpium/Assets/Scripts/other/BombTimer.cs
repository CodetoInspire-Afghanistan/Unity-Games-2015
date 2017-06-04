using UnityEngine;
using System.Collections;

public class BombTimer : MonoBehaviour {

	public AudioClip Timer;
 
	void OnTriggerEnter2D(Collider2D col){
 		if(col.CompareTag("Player")){
			AudioSource.PlayClipAtPoint (Timer,transform.position);
		}


	}
}
