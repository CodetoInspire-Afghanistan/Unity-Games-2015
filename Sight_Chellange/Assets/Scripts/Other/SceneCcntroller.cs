using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneCcntroller : MonoBehaviour {

	// Use this for initialization

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ChangeScene(string sceneName){
		SceneManager.LoadScene (sceneName);
	}

	public void CloseGame(){
		Application.Quit ();

	}
	public void Reply(){
		SceneManager.LoadScene ("1(1x1)");
		TimeController.time = 60;
		ScoreKeeper.scoreCalculator = 0;
		SkipLevel.skipCounter = 2;

	}
	public void CloseDuringLevel(){
		SceneManager.LoadScene ("StartMenu");
		TimeController.time = 60;
		ScoreKeeper.scoreCalculator = 0;
		SkipLevel.skipCounter = 2;
	}
}
