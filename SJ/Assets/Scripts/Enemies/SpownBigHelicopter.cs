using UnityEngine;
using System.Collections;

public class SpownBigHelicopter : MonoBehaviour {

	public GameObject BigHelicopter;
	public GameObject SmallJet;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame

	void Update(){


		if (ScoreKepper.currentScore >= 20) {
			BigHelicopter.gameObject.SetActive (true);
			SmallJet.gameObject.SetActive (false);

		}
}
}
