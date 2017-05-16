using UnityEngine;
using System.Collections;

public class InfoPanel : MonoBehaviour {

	public GameObject infopanel;
	public GameObject infopanelEmail;

	private bool check;
	private bool checking;

	// Use this for initialization
	void Start () {
	    check = true;
		checking = true;
	}

	//open panel of twitters address
	public void Twitter(){
		if (check == true) {
			infopanel.gameObject.SetActive (true);
			check = false;

		} else {
			infopanel.gameObject.SetActive (false);
			check = true;
		}
	}

	//open panel of emails address
	public void Email(){
		if (checking == true) {
			infopanelEmail.gameObject.SetActive (true);
			checking = false;

		} else {
			infopanelEmail.gameObject.SetActive (false);
			checking = true;
		}
	}
}
