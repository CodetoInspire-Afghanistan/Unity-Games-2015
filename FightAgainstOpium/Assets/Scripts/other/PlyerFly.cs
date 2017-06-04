using UnityEngine;
using System.Collections;

public class PlyerFly : MonoBehaviour {

	// Use this for initialization

	public GameObject player;
	int Playerstart=0;
	int Playerend=17;

	int HelicopterStart=0;
	int helicopterEnd=20;



	void Start () {
		InvokeRepeating ("Timer",0.0001f,1f);
		InvokeRepeating ("HelicopterTimer",0.0001f,1f);
		player.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Playerstart == Playerend) {
			player.gameObject.SetActive (true);
		}

		if(HelicopterStart==helicopterEnd){
			gameObject.SetActive (false);
		}
	}
	void Timer(){
		Playerstart++;
	}

	void HelicopterTimer(){
		HelicopterStart++;
	}


}
