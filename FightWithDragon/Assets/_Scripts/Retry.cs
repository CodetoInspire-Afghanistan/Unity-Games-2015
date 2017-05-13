using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour {
    //private SceneManager sceneManager;
    // Use this for initialization
    void Start () {
        // sceneManager=GameObject.FindObjectOfType<SceneManager>();

    }

    public void retry() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.currentSceneIndex);
         Add.projectile = 250;







        if (SceneManager.currentSceneIndex==3){
                            ScoreKeeper.score=0;
                            ScoreKeeper.x=0;
                        }
                        else if (SceneManager.currentSceneIndex==4){
                            ScoreKeeper.score=1000;
                            ScoreKeeper.x=0;
                        }

        else if (SceneManager.currentSceneIndex==5){
                            ScoreKeeper.score=2000;
                            ScoreKeeper.x=0;
                        }
                        else if (SceneManager.currentSceneIndex==6){
                            ScoreKeeper.score=3000;
                            ScoreKeeper.x=0;
                        }
                        else if (SceneManager.currentSceneIndex==7){
                            ScoreKeeper.score=4000;
                            ScoreKeeper.x=0;
                        }

    }
    // Update is called once per frame
    void Update () {
    }
}
