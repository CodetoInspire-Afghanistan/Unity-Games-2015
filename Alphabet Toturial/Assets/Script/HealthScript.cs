using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	Spawner sp;
	//for give health sprite
	[SerializeField]
	private GameObject[] Health;
	public static int hel;

	void Start () {
		//Access to gameobject of spawner
		sp = GameObject.FindObjectOfType<Spawner> ();
		hel = 0;
	}
	// when collision happend gameobject will destory
	void OnCollisionEnter2D(Collision2D other){
		Destroy (other.gameObject);
	}
	// for health by touchiny the wrong answer one health will have disable 
	public void Hit (){
		if (hel<5) {
			Health [hel].GetComponent<SpriteRenderer> ().enabled = false;
			hel++;
		}
	}
}
