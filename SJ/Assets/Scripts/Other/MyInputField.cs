using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class MyInputField : MonoBehaviour {

	public InputField inputField;
	public AudioClip typing;

	public Text text;
	private string myString = "You are choosed in this war!" +
		"You must fight with mafia and refine your city from them!";
	
	public float typeDelay= 0.3f;
	public string x;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			AudioSource.PlayClipAtPoint (typing,this.transform.position);
			 x = inputField.text.ToString ();
			myString = x +"! "+ myString;
			StartCoroutine ("TypeText");

		}
	}

	// an IEnumerator for writing a text automatically
		IEnumerator TypeText(){
			foreach (char letter in myString.ToCharArray()) {
				text.text += letter;
				yield return 0;
				yield return new WaitForSeconds (typeDelay);
			}

		}
	}