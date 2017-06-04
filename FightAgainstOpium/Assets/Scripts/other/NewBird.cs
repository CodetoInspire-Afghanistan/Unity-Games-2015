using UnityEngine;
using System.Collections;

public class NewBird : MonoBehaviour {
	 
 	// Use this for initialization
	void Start () {
  
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3(0.5f,0.5f)*Time.deltaTime*7);
	}




}
