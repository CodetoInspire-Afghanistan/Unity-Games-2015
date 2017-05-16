using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ProTextController : MonoBehaviour {
	private enum States {Startt, Game, App, Database};
	private States myStates;
	public Text firstText;
	// Use this for initialization
	void Start () {
		myStates = States.Startt;
	}
	
	// Update is called once per frame
	void Update () {
		if (myStates == States.Startt) {
			state_startt();
		}else if (myStates == States.Game) {
			state_Game ();
		}else if (myStates == States.App) {
			state_Application ();
		} else if (myStates == States.Database) {
			state_Database();
		}
	
	}
	void state_startt(){
		firstText.text = 
			"when u want that develope software, this program called a problem that must be solved!\n" +
			"Ur problem can be a:\n" +
			"1- Game\n" +
			"2- Application(PC app or Mobile app)\n" +
			"3- Database\n" +

			"If ur problem is a game, press G.\n" +
			"If ur problem is a application, press A.\n" +
			"If ur problem is a database, press D.\n";

		if (Input.GetKeyDown (KeyCode.G)) {
			myStates = States.Game;
		}
		else if (Input.GetKeyDown (KeyCode.A)) {
			myStates = States.App;
		}
		else if (Input.GetKeyDown (KeyCode.D)) {
			myStates=States.Database;
		}

	}
	void state_Game(){
		 
		firstText.text= "If u want that create a game,\n i suggestion to you that use from Unity game engine,\n" +
			"Its a powerfull framework that support 2D and 3D game\n" +
				"Now u spiecefy ur problem, so u must gather the information of client\n\n\n "+

				"Press N if u want go to next step!\n"+
				"Press R for Return";

if (Input.GetKeyDown (KeyCode.R)) {
			myStates=States.Startt;

		}else if (Input.GetKeyDown (KeyCode.N)) {
			Application.LoadLevel("Feasibility");
			
		}

	}
	void state_Application(){
		firstText.text = "Try that make new and benefite application program!\n" +
			"Its better that ur application be crros platform\n" +
			"Nowadays android appliacatio find more partisan\n\n\n" +
			"Press N if u want go to next step!\n" +
			"Press R for Return";
		if (Input.GetKeyDown (KeyCode.R)) {
			myStates=States.Startt;
			
		}else if (Input.GetKeyDown (KeyCode.N)) {
			Application.LoadLevel("Feasibility");
			
		}
	}
	void state_Database(){

		firstText.text = "Databases and database systems are an essential" +
			"component of life in modern society,\n" +
			"most of us encounter several activities every day that involve some interaction with a database\n\n\n" +
				"Press N if u want go to next step!\n"+
				"Press R for Return";


		if (Input.GetKeyDown (KeyCode.R)) {
			myStates=States.Startt;
			
		}else if (Input.GetKeyDown (KeyCode.N)) {
			Application.LoadLevel("Feasibility");
			
		}
	}







}