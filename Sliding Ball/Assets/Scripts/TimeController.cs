using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeController : MonoBehaviour {

	[SerializeField]
	private Text timeShowing;

	[SerializeField]
	private Text tShowing;

	[SerializeField]
	private Text timeSave;

	public static int time;
	public static int saveTime;
	public static int timeStr;
	public static bool isFinish = false;


	void timer(){
			time += 1;
	}

	// Use this for initialization
	void Start () {
		isFinish = false;
		if (!isFinish) {
			InvokeRepeating ("timer", 0f, 1f);
		}
	}

	// Update is called once per frame
	void Update () {
		timeShowing.text = "Time:" + time;

		tShowing.text = "Time:" + time; 

		timeSave.text = "Best Time:" + saveTime.ToString(); 
	}

	void OnCollisionEnter2D(Collision2D other){
			if (timeStr == 0) {
				saveTime = time + 1;
				timeStr = 10;
			}
		if (time < saveTime ) {
				saveTime = time + 1;
			}
	}
}
