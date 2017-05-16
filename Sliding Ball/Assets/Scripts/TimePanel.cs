using UnityEngine;
using System.Collections;

public class TimePanel : MonoBehaviour {

	[SerializeField]
	private GameObject panelTime;

	[SerializeField]
	private float time;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Timer", 0, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		if(time == 0){
			panelTime.gameObject.SetActive (true);
		}
	}

	//control the time
	void Timer(){
		if (time >0) {
			time -= 1; 
		}
	}
}
