using UnityEngine;
using System.Collections;

public class Pilot : MonoBehaviour {


	private Rigidbody2D myRigidbody;
	public float speedOfWalk = 0.5f;

	public GameObject Stand;
	public GameObject Walk;


	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		HandleMovement ();
	}

	//for controlling the movement of pilot
	void HandleMovement(){
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			Stand.gameObject.SetActive (false);
			Walk.gameObject.SetActive (true);
			gameObject.GetComponent<Rigidbody2D> ().velocity = speedOfWalk * new Vector2 (-5f, 3f);
		}
	}
}
