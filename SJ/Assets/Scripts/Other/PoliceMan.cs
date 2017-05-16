using UnityEngine;
using System.Collections;

public class PoliceMan : MonoBehaviour {


	private LevelManager levelManage;

	// Use this for initialization
	void Start () {
		levelManage = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			transform.position += Vector3.right;
		}else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			transform.position += Vector3.up;
		}else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			transform.position += Vector3.left;
		}else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			transform.position += Vector3.down;
		}
	}

	//for checking the collision game objects together
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("Player")) {
			Application.LoadLevel ("Jet_Flying");
		} else {
			levelManage.LoadNewScene ("Lose Screen");
		}


	}
}
