using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public static int currentSceneIndex;

   
	void Update(){

		if (Application.loadedLevel != 13) {
			currentSceneIndex = Application.loadedLevel;
		}
	}
    public void LoadScence(int senceNumber){
      //  Bottles.breakableCount=0;
        Application.LoadLevel (senceNumber);
    }
    public void LoadNewScene(string name){
     Application.LoadLevel (name);
    }
    public void quitGame(){
        Application.Quit();
    }
    public void LoadNextLevel(){
        Bottles.breakableCount=0;
        Application.LoadLevel(Application.loadedLevel+1);

    }
    void CountScore(){


        if(Application.loadedLevel==10 && ScoreKeeper.score==170){
            Application.LoadLevel("Exellent");
        }else if(Application.loadedLevel==10 && ScoreKeeper.score>=85){
            Application.LoadLevel("Good");
        }else if (Application.loadedLevel==10 && ScoreKeeper.score<85){
            Application.LoadLevel("Lose Screen");
        }
    }
//    public  void bottleDestroyed(){
//        if (Bottles.breakableCount<=0){
//            LoadNextLevel();
//        }
    }
