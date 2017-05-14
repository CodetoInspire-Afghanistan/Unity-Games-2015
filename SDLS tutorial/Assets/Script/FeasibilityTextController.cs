using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FeasibilityTextController : MonoBehaviour {

	private enum States{Feasibility, Failed, Success};
	private States myStates;
	public Text text;
	void Start () {
		myStates = States.Feasibility;
	}

	void Update () {
	if (myStates == States.Feasibility) {
			state_Feasibility ();
	} else if (myStates == States.Failed) {
			state_Failed ();
	} else if (myStates == States.Success){
			state_Success();
		}
		}


		void state_Feasibility(){
			text.text=
				"Study of whether the project is feasible.\n"+
					"Some problems are impossible to be solved!\n\n\n "+
					
					"If ur problem is feasible press S for go to Success state\n"+ 
					
					"If ur problem is not feasible press F for go to Failed state and try again !";
					
					

	     if (Input.GetKeyDown (KeyCode.F)) {
			myStates = States.Failed;
		} else if (Input.GetKeyDown (KeyCode.S)) {
			myStates=States.Success;
		}
	}

		void state_Failed(){
		text.text = "Sorry!\n" +
			"Ur problem is not feasible\n\n" +
			"press R to return, dispense from current problem\n" +
			"and go to state to create a feasible software !";


		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel ("Problem");

		}
	}
		void state_Success(){

			text.text="Congratulation!\n" +
				"Ur problem is feasible to develope:)\n\n"+
				"Pres N to go to next step of SDLC ";
	if (Input.GetKeyDown (KeyCode.N)) {
		Application.LoadLevel ("Reqiurement");
		}

}}




	