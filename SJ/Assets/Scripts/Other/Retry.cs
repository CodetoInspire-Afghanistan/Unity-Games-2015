using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Retry : MonoBehaviour {


	//for retry playing of a level 
    public void retry(){
		Application.LoadLevel(LevelManager.currentSceneIndex);
		if (LevelManager.currentSceneIndex == 2) {
			ScoreKepper.currentScore = 0;

		}else if (LevelManager.currentSceneIndex == 3) {
			ScoreKepper.currentScore = 500;

		}else if (LevelManager.currentSceneIndex == 4) {
			ScoreKepper.currentScore = 1200;

		}else if (LevelManager.currentSceneIndex == 5) {
			ScoreKepper.currentScore = 1800;

		}








}
			}
