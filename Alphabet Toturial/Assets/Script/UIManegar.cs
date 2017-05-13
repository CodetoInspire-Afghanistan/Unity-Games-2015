using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
   

public class UIManegar : MonoBehaviour {
	public Sprite playing;
	bool IsPuse;
	public GameObject playBtn;
	public GameObject PauseBtn;

	// Use this for initialization
	void Start () {
		IsPuse = false;
		
	}

	

	// for stop and run applacation
	public void Puse(){
		IsPuse = !IsPuse;
		if (IsPuse) {
			Time.timeScale = 0;
			playBtn.SetActive (true);
			PauseBtn.SetActive (false);

		}
		else if(!IsPuse){ 
			Time.timeScale=0;
			playBtn.SetActive (false);
			PauseBtn.SetActive (true);
		}

	

	}


	
}
