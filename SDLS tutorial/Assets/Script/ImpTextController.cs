using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImpTextController : MonoBehaviour {
	private enum States{Implement, General_Coding, Details_Coding};
	private States myStates;
	public Text text;

	// Use this for initialization
	void Start () {
		myStates = States.Implement;
	}
	
	// Update is called once per frame
	void Update () {
	if (myStates == States.Implement) {
			state_Implement ();
		} else if (myStates == States.General_Coding) {
			state_General_Coding ();
		} else if (myStates == States.Details_Coding) {
			state_Details_Coding ();
		}
	}

	void state_Implement(){
		text.text = "This step is also known as programming phase. \n" +
			"The implementation of software design starts in terms of writing program code \n" +
			"in the suitable programming language and developing error-free executable programs efficiently.\n" +
			"So press G to start general coding!\n" +
			"\nPress R for Return!";
	

		if (Input.GetKeyDown (KeyCode.G)) {
			myStates=States.General_Coding;
		}else if(Input.GetKeyDown(KeyCode.R)){
			Application.LoadLevel("Design");}
	}
	void state_General_Coding(){

		text.text = "U can implement ur program with different programming language!\n" +
			"For eg. Java, C, C++, CSharp\n\n" +
			"Also u need a IDE to write ur code!\n" +
			"My suggestion is eclips editor\n\n" +
			"If u written the general parts of code , press D to write Details of coding\n" +
			"Press R for return";
		if (Input.GetKeyDown (KeyCode.R)) {
			myStates=States.Implement;
		}else if(Input.GetKeyDown (KeyCode.D)){
			myStates=States.Details_Coding;

		}
	}
	void state_Details_Coding(){
			text.text = "After that u written the general parts of code,\n" +
				"U must consider some slight part of code and special situation!\n\n" +
				"if ur implementation step is finished Press N to go to next step and run ur program!\n" +
				"Press R for return";

			if(Input.GetKeyDown(KeyCode.N)){
				Application.LoadLevel("Run");
			}
			else if(Input.GetKeyDown(KeyCode.R)){
				myStates=States.General_Coding;
			}
	}




}
