using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class loadingtimer : MonoBehaviour {

    int maxTime=10;
    int minTime=0;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Timer",0.0001f,1f);
	}
	
	// Update is called once per frame
	void Update () {
	if(minTime==maxTime){
    SceneManager.LoadScene("Start");
}
    }


	//for increasing the time
    public void Timer(){
     minTime++;



    }

}
