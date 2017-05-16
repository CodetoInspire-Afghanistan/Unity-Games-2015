using UnityEngine;
using System.Collections;

public class Helping : MonoBehaviour {

	// Use this for initialization
    public GameObject Help;
    int current_Time = 0;
   int maxTime = 30;

	void Start () {
	InvokeRepeating("Time",0.0001f,1f);
	}
	
	// Update is called once per frame
	void Update () {
    if(current_Time == maxTime){
			Destroy (Help.gameObject);

   		 }
	}

	//for aactivation of helper jet in a limit time
    void OnMouseDown() {

		Help.gameObject.SetActive(true);
        InvokeRepeating("Timer",0.0001f,1f);


		// calculate the limitiaion of time
    }
    void Timer(){
 
		current_Time += 1;
        if(current_Time==maxTime){
            CancelInvoke("Timer");

        }

    }

}
