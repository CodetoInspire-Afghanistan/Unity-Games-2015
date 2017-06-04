using UnityEngine;
using System.Collections;

public class EnableAnimator : MonoBehaviour {
	public GameObject myGameObject;
	public GameObject explotion1;
	public GameObject explotion2;
	int first=0;
	int end=3;

 	// Use this for initialization
	void Start () {
 	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "shell") {
			this.gameObject.SetActive (false);
			//explotion1.gameObject.SetActive (true);
			//explotion2.gameObject.SetActive (true);
			myGameObject.SetActive (true);
		}
	}
	void OnTriggerStay2D(Collider2D other){
		first++;
		if(first==end){
			explotion1.gameObject.SetActive (false);
			explotion2.gameObject.SetActive (false);
		}
		}


}
