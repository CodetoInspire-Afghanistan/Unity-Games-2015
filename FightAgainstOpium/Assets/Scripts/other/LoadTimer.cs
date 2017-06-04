using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadTimer : MonoBehaviour {

	// Use this for initialization
	int currentTime=0;
	public int  endTime=12;
	public int SceneNumber;

	void Start () {
		InvokeRepeating ("UpdateTime",0.00001f,1f);
	}
	
	// Update is called once per frame=
	void Update () {
		if(currentTime==endTime){
			SceneManager.LoadScene (SceneNumber);

		}
	}
	void UpdateTime(){

		currentTime++;
	}
}
