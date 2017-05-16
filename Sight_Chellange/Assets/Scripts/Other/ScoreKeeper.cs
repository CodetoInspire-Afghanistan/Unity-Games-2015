using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	// Use this for initialization

	public  Text score;
	public static int scoreCalculator=0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		score.text = scoreCalculator.ToString ();
	}

	public static void UpdateScore(int increaseScore){

		scoreCalculator += increaseScore;
	}

	public static void DecreaseScore(){
		scoreCalculator -= 1;
	}
}
