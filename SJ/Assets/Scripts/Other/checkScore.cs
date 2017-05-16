using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class checkScore : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        if (ScoreKepper.currentScore >= 1800) {
            SceneManager.LoadScene("Missions");
        }
	}
}
