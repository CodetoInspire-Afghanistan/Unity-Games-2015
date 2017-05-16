using UnityEngine;
using System.Collections;

public class GiftBottuns : MonoBehaviour {

	// Use this for initialization
	public GameObject P1;

	//for activation of jet
	void OnMouseDown(){
		P1.gameObject.SetActive (true);

	}
}
