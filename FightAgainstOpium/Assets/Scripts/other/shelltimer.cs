using UnityEngine;
using System.Collections;

public class shelltimer : MonoBehaviour {
	public GameObject desible;
	// Use this for initialization
	int startTime= 0;
	int endtime=3;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(startTime==endtime){
			desible.gameObject.SetActive (false);
		}
	}
	void timer(){
		startTime++;

			}
}
