using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReTry : MonoBehaviour {
	
	public static bool isStarted;

	public void RETRY(){
		SceneManager.LoadScene (SceneManage.currentSceneIndex);
		isStarted = true;

    	TimeController.time = 0;

	}

}

