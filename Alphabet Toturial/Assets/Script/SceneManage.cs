using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneManage : MonoBehaviour {
	public static int currentStat;

	[SerializeField]
	private Button [] button;


	public void load(int number){
		

		SceneManager.LoadScene(number);
		score.scoreSta = 0;
	}

	void Start(){
	 Camera.main.projectionMatrix=Matrix4x4.Ortho(-7.0f*1.6f,7.0f*1.6f,-7.0f,7f,0.3f,2000f);

	}
		
	void Update(){
		LoseLevel ();	
	}
	//load next level when user take score
	public void LoadNextLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}

	public void Replay(){
		
		spawnwords.ind = 0;
		WordTouching.wordIndex = 0;
		touching.myString = "";
		touching.wordIndex = 0;
		WordTouching.myString = "";
		// load the first level with the zero score and so on
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 1) {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
			score.scoreSta = 0;

		}
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 2) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
			score.scoreSta = 20;

		}
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 3) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
			score.scoreSta = 40;

		}
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 4) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
			score.scoreSta = 60;
		}
	} 

	void OnLevelWasLoaded(){
		Time.timeScale = 1;
	}


	//reload level when player lose 
	public void LoseLevel(){
		if (Time.timeScale == 1) {
			foreach (Button b in button) {
				if (HealthScript.hel >= 5) {
					b.gameObject.SetActive (true);
					Time.timeScale = 0;

				}
			}
		}
	}


	//Exit applacation
	public void Exit(){
		Application.Quit();
	}
}
