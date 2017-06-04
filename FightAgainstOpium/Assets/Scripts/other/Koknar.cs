using UnityEngine;
using System.Collections;

public class Koknar : MonoBehaviour {

	public Sprite Damaged;

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.CompareTag ("shell")) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = Damaged;
			gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			col.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			Destroy (col.gameObject);
	
			GameManager.collectedCoins += 50;
		}
	}
}
