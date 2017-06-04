using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {
	
	private Animator myAnimator;

	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator> ();

	}


	
	// Update is called once per frame
	void Update () {

	}


	void OnTriggerEnter2D(Collider2D other){
 			
				gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		gameObject.SetActive (false);

	}



	void OnCollisionEnter2D(Collision2D other){
	gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		gameObject.SetActive (false);

		}




    IEnumerator Disabling(){


		yield return new WaitForSeconds(4);	


}
}
