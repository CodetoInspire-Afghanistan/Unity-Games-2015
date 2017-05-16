using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour {

	public static int time=60;
	public Text timeDisplay;

	// Use this for initialization
	void Start () {
		if (time > 0) {
			
			InvokeRepeating ("UpdateTime", 0.0001f, 1f);
		}
	}


	void Update () {

		if(time <= 60 && time>=40){
			timeDisplay.gameObject.GetComponent<Text> ().color = new Color (0f,1f,0.1294f);
		}
		if(time <= 40 && time >=20){

			timeDisplay.gameObject.GetComponent<Text> ().color = new Color (1f,0.9686f,0.5215f);
		}
	if(time <= 20 && time>=10){

		timeDisplay.gameObject.GetComponent<Text> ().color = new Color (1f,0.5231f,0.1921f);
}
		if(time <= 10 && time >=0){
			timeDisplay.gameObject.GetComponent<Text> ().color = new Color (1f,0.1019f,0f);

		}





		if (time == 0) {
			if (ScoreKeeper.scoreCalculator >= 0 && ScoreKeeper.scoreCalculator <= 9) {
				SceneManager.LoadScene ("Low");

			}
			else if (ScoreKeeper.scoreCalculator >9 && ScoreKeeper.scoreCalculator <= 15){

				SceneManager.LoadScene ("Normal");
		    }
		else if (ScoreKeeper.scoreCalculator>15 && ScoreKeeper.scoreCalculator <= 29){

			SceneManager.LoadScene ("Good");
	
	    }
		else if (ScoreKeeper.scoreCalculator >=30){

		SceneManager.LoadScene ("Prefect");
	}

		}
	}
	void UpdateTime(){
			time -= 1;
		timeDisplay.text = time.ToString ();
	}
}
