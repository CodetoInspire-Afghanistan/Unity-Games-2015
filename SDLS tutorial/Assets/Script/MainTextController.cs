using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MainTextController : MonoBehaviour {

	// Use this for initialization
	private enum States{Maintenance, corrected_version, service_package, major_revision};
	private States myStates;
	public Text text;
	void Start () {
		myStates = States.Maintenance;
	}
	
	// Update is called once per frame
	void Update () {
	if (myStates == States.Maintenance) {
			state_Maintenance ();
		} else if (myStates == States.corrected_version) {
			state_corrected_version ();
		} else if (myStates == States.service_package) {
			state_Service_package ();
		} else if(myStates==States.major_revision){
			state_Major_revision ();
		}
	}

	void state_Maintenance (){
		text.text = 
					"After the software has been delivered, its developers remain obliged to maintain it with:\n\n"+

					"1.corrected versions\n"+
					"2.service packages\n"+
					"3.major revisions\n\n\n" +
					"Press C to corrected version\n" +
					"Press S to do service package\n" +
					"Press M to major revision";


		if (Input.GetKeyDown (KeyCode.C)) {
			myStates = States.corrected_version;
		} else if (Input.GetKeyDown (KeyCode.S)) {
			myStates = States.service_package;
		} else if (Input.GetKeyDown (KeyCode.M)) {
			myStates = States.major_revision;
		}
	}
	void state_corrected_version (){
		text.text = "This version of ur program has some problems\n" +
			"This problems may occurrance in codig or in design!\n\n" +
			"If u want correct implementation, Press I\n" +
			"If u want correct design, Press D\n\n" +
			"Press R to return";

		if (Input.GetKeyDown (KeyCode.I)) {
			Application.LoadLevel ("Implement");
		} else if (Input.GetKeyDown (KeyCode.D)) {
			Application.LoadLevel("Design");
		}else if(Input.GetKeyDown (KeyCode.R)) {
			myStates = States.Maintenance;


		}

	}
	void state_Service_package (){
		text.text="In service Package state, u must provide some services for ur software\n" +
			"For do it , u must return in start state!\n\n\n"+
			"Press S to Start\n" +
			"Press R to return\n";



		if (Input.GetKeyDown (KeyCode.S)) {
			Application.LoadLevel ("Start");
			} else if (Input.GetKeyDown (KeyCode.R)){
			myStates = States.Maintenance;
	}
}
	void state_Major_revision (){
		text.text = "Any major revision itself would follow the same life cycle steps\n" +
			"You must redisign ur software!\n\n"+
			"Press R to return\n\n" +
				"Press D to redesign"; 


		if (Input.GetKeyDown (KeyCode.R)) {
			myStates = States.Maintenance;
			}else if (Input.GetKeyDown (KeyCode.D)) {
			Application.LoadLevel("Design");}

	}
}

