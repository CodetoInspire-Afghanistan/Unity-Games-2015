using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SafferonController2 : MonoBehaviour {

	// Use this for initialization
	public Button Safferon;
	public GameObject Saff;
	public Sprite OK;
	//public BoxCollider2D box;

	void Start () {
		Saff.SetActive (false);
		//Safferon.gameObject.SetActive (false);

	}



	public void GrowSafferon(){
		Saff.SetActive (true);
		Safferon.gameObject.GetComponent<Image> ().sprite = OK;
	}
}