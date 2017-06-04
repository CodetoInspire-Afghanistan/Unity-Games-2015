using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SafferonController3 : MonoBehaviour {

	// Use this for initialization
	public Button Safferon;
	public GameObject Saff2;
	public Sprite OK;

	void Start () {
		Saff2.SetActive (false);

	}

	public void GrowSafferon(){
		Saff2.SetActive (true);
		Safferon.gameObject.GetComponent<Image> ().sprite = OK;
	}
}