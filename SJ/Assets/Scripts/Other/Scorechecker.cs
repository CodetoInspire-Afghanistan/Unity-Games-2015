using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scorechecker : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
        if (ScoreKepper.currentScore >= 2550) {
            SceneManager.LoadScene("WinScreen");
        }
	}
}
