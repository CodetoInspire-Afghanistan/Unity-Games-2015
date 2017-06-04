using UnityEngine;
using System.Collections;

public class ClosePanels : MonoBehaviour {

	public GameObject KeyPanel;
	public GameObject BombPanel;
	public GameObject UndergroundPanel;
	public GameObject SaferonPanel;

	public void CloseKeyPanel(){
		KeyPanel.SetActive (false);

	}

	public void BombPanelCloser(){
		BombPanel.SetActive (false);
	}

	public void CloseUnderGroundPanel(){

		UndergroundPanel.SetActive (false);
	}

	public void SafferonPanel(){
		SaferonPanel.SetActive (false);

	}
}
