using UnityEngine;
using System.Collections;

public class StopReading : MonoBehaviour {

	// Use this for initialization

	public GameObject Word;
	public GameObject StoryPanel;

	void OnMouseDown(){
		Word.SetActive (true);
		StoryPanel.SetActive (false);

	}
}
