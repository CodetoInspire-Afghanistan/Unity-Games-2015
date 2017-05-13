using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreKeeper : MonoBehaviour {
	
	public Text text;
	public static int score = 0;


	// Use this for initialization
	void Start () {
		text.text = score.ToString ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void add(int amount){

		score += amount;

		text.text = score.ToString ();
	}


}