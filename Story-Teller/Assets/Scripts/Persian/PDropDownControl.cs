using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PDropDownControl : MonoBehaviour {
	public Dropdown dropDown;
	public Text Etext;
	//public Text Etext;



	// Use this for initialization
	void Start () {

		//Etext.text= "English";


		//dropDown.GetComponent<Text> ();
	}

	// Update is calledonce per frame
	void Update () {
		Etext.text = "English";
		//Etext.text= "English";

		if (dropDown.captionText.text == Etext.text) {

			//print ("persian");
			SceneManager.LoadScene("MainMenu");
		}
		//		else if(dropDown.captionText.text == Etext.text) {
		//						SceneManager.LoadScene ("MainMenu");

	}
}





