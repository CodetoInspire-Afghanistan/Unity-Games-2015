using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour {

    public static int currentSceneIndex;
    void  Update() {
        if (Application.loadedLevel != 8) {
            currentSceneIndex = Application.loadedLevel;


        }
    }
    public void LoadScene (string name) {

        UnityEngine.SceneManagement.SceneManager.LoadScene(name);

    }

    public void LoadNextLevel() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitRequest () {
        Application.Quit();
    }
}
