using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour {

	void Awake(){
		Camera.main.projectionMatrix = Matrix4x4.Ortho (-2*17f,2*17f,-2f*10f,10f*2f,0.3f,1000);
	}
 	void Start(){
 	}

    public void Scene(string level) {
		if (MyTextField.firstPlayer !="" && MyTextField.secondPlayer!="") {
			SceneManager.LoadScene(level);
		}

	}
        public void LoadScene(string name){
            SceneManager.LoadScene(name);
		if(name=="BeforStartMenu"){
			myCanvasFirstLevel.y = false;
			myCanvasSecondLevel.y = false;

		}

	}


    public void QuitGame(){
        Application.Quit();
    }

	void Update() {
 
		if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex==4 || UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex==5  ){

		}



	}









}