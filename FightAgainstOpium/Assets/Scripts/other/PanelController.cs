using UnityEngine;
using System.Collections;

public class PanelController : MonoBehaviour {

	// Use this for initialization

	public GameObject Panel;
	int StartTime=0;
	int EndTime=4;
	void Start () {
		Panel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Timer(){
		StartTime++;
	}
}
