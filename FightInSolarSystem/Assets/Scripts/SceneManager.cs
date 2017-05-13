using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
	public static int currentSceneIndex;

 public GameObject prefabGol;

 	void Start() {
	}
	public void LoadScene (string name){
        Brick.breakableCount=0;
		UnityEngine.SceneManagement.SceneManager.LoadScene (name);
    }

    public void LoadNextLevel(){
        Brick.breakableCount=0;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);


    }


	public void QuitRequest (){
		print ("Quit Requested");
		Application.Quit ();
	}



    public void brickDestroyed(){
        if(Brick.breakableCount<=0 && !Brick.ghoulInstantiated){
        Instantiate(prefabGol);
         Brick.ghoulInstantiated = true;
        }

        else if(Brick.breakableCount<=0 && Brick.ghoulInstantiated){
             Brick.ghoulInstantiated =false;
        LoadNextLevel();
        }
    }


	void  Update ()
	{
		if (Application.loadedLevel != 21) {
			currentSceneIndex = Application.loadedLevel;


		}


	}
}
