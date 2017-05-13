using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Timer : MonoBehaviour {

	public Text time;
	public int current_Time=0;
	public int max_Time=70;
	//private Timer timer;
	void Start () {

        current_Time=max_Time;
		InvokeRepeating("IncreaseTime",0f,1f);
	}

	
	void Update () {
		
		
		if (current_Time==0){
			
			time.text=current_Time+"";

			ScoreKeeper.score = 0;
			//Application.LoadLevel("Lose Scrin");
            Bird.killedBirds = 0;
            SceneManager.LoadScene("Lose Scrin");
		}
	}
	void IncreaseTime(){
		current_Time-=1;
		time.text=current_Time+"";
	}
}


