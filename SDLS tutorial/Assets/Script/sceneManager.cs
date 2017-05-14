using UnityEngine;
using System.Collections;

public class sceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void LoadScence(string numberSence){
		Application.LoadLevel (numberSence);
	}
	public void quitGame(){
		Application.Quit();
	}

}
