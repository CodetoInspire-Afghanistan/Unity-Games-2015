using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {
	
	public static int currentSceneIndex;

	// Update is called once per frame
	void Update(){
		if (Application.loadedLevel != 8) {
			currentSceneIndex = Application.loadedLevel;
		}
	}
	//for loading a new scene of game

	public void LoadNewScene(string sceneName){
		SceneManager.LoadScene(sceneName);

	}

	//for closing the game
	public void Quit(){
		Application.Quit ();
	}
		

	//for loading next level of game
	void LoadNextScene(){

		if (ScoreKepper.currentScore >= 230) {
            SceneManager.LoadScene("Level_03");
		}
	}

	//for retrying the pervious level
	public void RetryNow(){

		Application.LoadLevel (Application.loadedLevel);
		ScoreKepper.currentScore = 0;
	}
	//reset the socre of player
    public void Reset(){
        ScoreKepper.currentScore = 0;

    }
}
