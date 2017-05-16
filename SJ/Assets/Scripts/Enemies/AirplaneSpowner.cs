using UnityEngine;
using System.Collections;

public class AirplaneSpowner : MonoBehaviour {
	public GameObject SmallJet;
	public GameObject BigJet;
	void Start () {
	}

	// Update is called once per frame

	void Update(){


		if (ScoreKepper.currentScore >= 300) {
			BigJet.gameObject.SetActive (true);
			SmallJet.gameObject.SetActive (false);

		}
	}
}

