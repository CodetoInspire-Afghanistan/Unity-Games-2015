using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	// Use this for initialization
	private int startTime=0;
	private float maxTime=6f;

	void Start () {
		InvokeRepeating ("Timer",0.001f,1f);
	}
	
	// Update is called once per frame
	void Update () {
		if (startTime == maxTime) {
			SceneManager.LoadScene ("MainMenu");

		}
	}
	void Timer(){

		startTime++;
	}

}
