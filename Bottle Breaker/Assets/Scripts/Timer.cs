using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	// Use this for initialization
    public int sceneNumber;
    public Text time;
    public int current_Time=0;
    public int max_Time=60;

	void Start () {
	current_Time=max_Time;
        InvokeRepeating("IncreaseTime",0f,1f);
	}
	
	// Update is called once per frame



    void Update () {
	if (current_Time==0){

        time.text=current_Time.ToString();
        LoadNextLevel();
    }
	}
    void IncreaseTime(){
        current_Time-=1;
        time.text=current_Time.ToString();
    }public  void LoadNextLevel(){
    if (Application.loadedLevel == 10){
        if(ScoreKeeper.score>=140 || ScoreKeeper.score==160){
            Application.LoadLevel("Exellent");
        }else if(ScoreKeeper.score>=80 ){
            Application.LoadLevel("Good");
        }else if(ScoreKeeper.score<80){
            Application.LoadLevel("Lose Screen");
        }

    }else{
        Application.LoadLevel(sceneNumber);
    }
}
}
