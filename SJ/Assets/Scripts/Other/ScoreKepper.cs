using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKepper : MonoBehaviour {

	// Use this for initialization
	public static int currentScore;
	public Text text;


	// Update is called once per frame
	void Update () {
		text.text = currentScore + "";
	}

	// for updateing of player scores
	public void IncreaseScore(int amount){
		currentScore += amount;
	}

}
