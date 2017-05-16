using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RunTextController : MonoBehaviour {
	private enum States{Run, Run_Failed, Run_Success};
	private States myStates;
	public Text text;
	// Use this for initialization
	void Start () {
		myStates = States.Run;
	}
	
	// Update is called once per frame
	void Update () {
	if (myStates == States.Run) {
			state_Run ();
		} else if (myStates == States.Run_Failed) {
			state_Run_Failed ();
		} else if (myStates == States.Run_Success) {
			state_Run_Success ();
		}
	}
	void state_Run(){
		text.text = "The implementation of program is finished and u complete the code!\n"+
"Now u must run the program and check the result!\n\n\n"+
"If the run result will be correct,Press S for go to the success state and countinue other steps!\n"+
"If the run result will not be successfull, Press E to go to Error_Occurrence state\n" +
", in this state u will know what shoud u do when the result of run be failed";

		if (Input.GetKeyDown (KeyCode.S)) {
			myStates=States.Run_Success;
		} else if (Input.GetKeyDown (KeyCode.E)) {
			myStates=States.Run_Failed;
		}
	}
	void state_Run_Failed(){
		text.text = "Error Occurrence\n" +
			"the run result is not successfull, and u cant go to next step\n\n" +
			"Press I for back to the implement state and debug ur coding";
		if (Input.GetKeyDown (KeyCode.I)) {
			Application.LoadLevel("Implement");
		}

	}
	void state_Run_Success(){
		text.text = "No Problem :) \n\n" +
			"the result of run is correct\n\n" +
			"Press N to go to next step and test ur softaware\n" +
			"Press R to return in Run state";

		if (Input.GetKeyDown (KeyCode.N)) {
			Application.LoadLevel ("Test");
		} else if (Input.GetKeyDown (KeyCode.R)) {
			myStates=States.Run;
		}
	}

}
