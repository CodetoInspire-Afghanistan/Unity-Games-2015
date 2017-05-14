using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class myCanvasFirstLevel : MonoBehaviour {
    public static bool y=false;
    public GameObject myGameOb;
    GameObject myGm;

    //    public GameObject myGameOb2;
    //    GameObject myGm2;
    public  void Awake() {
        if (!y) {
            myGm = Instantiate(myGameOb) as GameObject;
            myGm.transform.SetParent(gameObject.transform);

            y = true;
        }
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType(GetType()).Length > 1) {
            Destroy(gameObject);
        }
	




    }
      void Update () {
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 2 || UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 4 || UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 5) {
            myGm.SetActive(true);
			if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 4 || UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 5){
				Destroy (gameObject);
				Destroy (myGm);

			}
        }
        else  {
            myGm.SetActive(false);
        }


    }
}



