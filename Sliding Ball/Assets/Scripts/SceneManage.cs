using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneManage : MonoBehaviour {

	public static int currentSceneIndex;

	[SerializeField]
    private GameObject panel;

	//resposive the screen size
	void Awake(){
		Camera.main.projectionMatrix=Matrix4x4.Ortho(-1.8f*1.6f,1.8f*1.6f,-5.0f,5f,0.3f,1000f);

		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}


	public void load(string name){
		Time.timeScale = 1;
		SceneManager.LoadScene(name);
	}


	public void load_Menue(){
		Time.timeScale = 1;
		ReTry.isStarted = true;
		TimeController.time = 0;
		SceneManager.LoadScene("Menu");
	}

		
	void Update(){
		
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex != 29) {
			currentSceneIndex =UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
		}
	}

	public void Pause(){
			if (Time.timeScale == 1) {
				Time.timeScale = 0;
				panel.gameObject.SetActive (true);
			}
	}

	public void LoadNextLevel(){
		Time.timeScale = 1;
		TimeController.saveTime = 0;
		TimeController.timeStr = 0;
		TimeController.time = 0;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}

	public void Replay(){
		TimeController.isFinish = false;
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1;
		TimeController.time = 0;
	} 

	public void Continue(){
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
			panel.gameObject.SetActive (false);
		}
	}
		
	public void Exit(){
		Application.Quit();
	}

	public void SoundPanel(){
		panel.gameObject.SetActive (true);
	}

	public void CloseSoundPanel(){
		panel.gameObject.SetActive (false);
	}
		
}
