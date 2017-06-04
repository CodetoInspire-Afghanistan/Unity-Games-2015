using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	// Use this for initialization
	public GameObject SoundPanel;
	public GameObject GeneralPanel;


	public void ShowSettingPanel(){

		SoundPanel.SetActive (true);
		GeneralPanel.SetActive (false);
	}


	public void DontShowSettingPanel(){

		SoundPanel.SetActive (false);
		GeneralPanel.SetActive (true);

	}
}
