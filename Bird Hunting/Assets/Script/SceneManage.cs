using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour {
   //  private Bird bird;
	public static int currentSceneIndex;

    void Start(){
      //  bird= GameObject.FindObjectOfType<Bird>();
    }
	public void loadScript(string name){

		//Application.LoadLevel(name);
        SceneManager.LoadScene(name);


	}

	void Update(){

		if (Application.loadedLevel != 20) {
			currentSceneIndex = Application.loadedLevel;
		}

	}

	public void LoadNextLevel(){
		Bird.killedBirds = 0;
		//Application.LoadLevel (Application.loadedLevel + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}

	public void Quiterequest(string name){
		Application.Quit();
	}

	public void BirdDestroyed(){
		if (Bird.killedBirds == 0) {
			LoadNextLevel();
		}
	}

}
