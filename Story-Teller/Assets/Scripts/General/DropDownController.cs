using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class DropDownController : MonoBehaviour {
	public Dropdown dropDown;
	public Text Ptext;
	//public Text Etext;



	// Use this for initialization
	void Start () {
		
	//Etext.text= "English";


		//dropDown.GetComponent<Text> ();
	}
	
	// Update is calledonce per frame
	void Update () {
		Ptext.text = "Persian";
		//Etext.text= "English";

		if (dropDown.captionText.text == Ptext.text) {

			//print ("persian");
			SceneManager.LoadScene("PMainMenu");
		}
//		else if(dropDown.captionText.text == Etext.text) {
//						SceneManager.LoadScene ("MainMenu");

}
}





