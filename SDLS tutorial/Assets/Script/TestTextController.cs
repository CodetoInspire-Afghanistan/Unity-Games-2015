using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestTextController : MonoBehaviour {
	private enum States{Test, Individual_Test,All_Part_Test,Product_Test,See_Test_Result,Test_Failed,Test_Success};
	private States myStates;
	public Text text;
	// Use this for initialization
	void Start () {
		myStates = States.Test;
	}
	
	// Update is called once per frame
	void Update () {
		if (myStates == States.Test) {
			state_Test ();
		} else if (myStates == States.Individual_Test) {
			state_Indivisual ();
		} else if (myStates == States.All_Part_Test) {
			state_All_Part ();
		} else if (myStates == States.Product_Test) {
			state_Pro_Test ();
		} else if (myStates == States.Test_Failed) {
			state_testFail ();
		} else if (myStates == States.Test_Success) {
			stste_testSuccess ();
		} else if (myStates == States.See_Test_Result) {
			state_seeResult ();
		}
	
	}



	void state_Test (){
		text.text = "The testing team attempts to ensure that the resulting software satisfies the requirements document.\n"+

"Failure at this point may require a redesign or even some fine-tuning of the requirements\n"+

"Testing occurs at several levels:\n\n"+

"1.Indivisual Testing.\n"+
"2.All parts together testing.\n"+
"3.Finally whole product testing.\n\n\n"+


"Press S to start the test parts";
		if (Input.GetKeyDown (KeyCode.S)) {
			myStates= States.Individual_Test;
		}
	}
	void state_Indivisual(){
		text.text = "In this state individual classes and methods are tested separately\n\n\n" +
			"Press C to continue testing\n" +
			"Press R to return";

		if (Input.GetKeyDown (KeyCode.C)) {
			myStates = States.All_Part_Test;
		} else if (Input.GetKeyDown (KeyCode.R)) {
			myStates = States.Test;
		}
	}
	void state_All_Part (){
		text.text = "In this state their success at working together is tested\n\n\n" +
			"Press C to countinue testing\n" +
			"Prees R to return";
		if (Input.GetKeyDown (KeyCode.C)) {
			myStates = States.Product_Test;
		} else if (Input.GetKeyDown (KeyCode.R)) {
			myStates = States.Individual_Test;
		}
	}
	void state_Pro_Test(){
		text.text = "finally, the product as a whole is tested against the requirements document\n\n"+
		"Now the steps of test is finished!\n\n" +
			"Press S to see the result of test!";
		if (Input.GetKeyDown (KeyCode.S)) {
			myStates = States.See_Test_Result;
		}
	}

	void state_seeResult (){
		text.text = "There are 2 probability:\n" +
			"1. The result of the test be failed\n" +
			"2. The result of the test be success\n\n\n" +
			"Press F to go to Failed state , to learn what should u do !\n" +
			"Press S to go to Success state to countinue...!";

	


		if (Input.GetKeyDown (KeyCode.F)) {
			myStates = States.Test_Failed;
		} else if (Input.GetKeyDown (KeyCode.S)) {
			myStates = States.Test_Success;
		}
	}

		void state_testFail (){
		text.text = "If the resultt of test is not successful u must find the reason:\n\n" +
			"1_ If the result of test was not according to the clienrt requirment, " +
			"u must back to requriment step and start from first!\n" +
			"2_ If the result of test was not correct and ur design had problem," +
			"u must back to design step and and repeate steps correctly\n\n\n" +
			"Press R to back to Requrment step! \n" +
			"Press D to back to Design step!";


		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel("Reqiurement");
		}else if(Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel("Design");
		}



		}
		void stste_testSuccess(){
		text.text = "Very Good!\n\n" +
			"The result of test was correct and according to the client requirments!\n\n\n" +
			"Press N to go to next step of SDLC";

		if (Input.GetKeyDown (KeyCode.N)) {
			Application.LoadLevel("Product");
		}
	}
	}

