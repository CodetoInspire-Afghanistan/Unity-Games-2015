using UnityEngine;
using System.Collections;

public class Panel : MonoBehaviour {
	
	public GameObject panelShow;
	public GameObject button;
	public static bool isPanelShow;
	private bool isPanelHide=true;


	//for active and deactivate paneles
	public void ShowPanel(){
		if (isPanelHide) {
				panelShow.gameObject.SetActive (true);
			isPanelHide = false;
		
			}
		else if (!isPanelHide) {
				panelShow.gameObject.SetActive (false);
			isPanelHide = true;


		} 
	}
	//when player touch the  button screen will have stoped and buttons will be active.
	public void showbutton(){
		if (Time.timeScale == 1 ) {
			button.gameObject.SetActive (true);
			Time.timeScale = 0;
			isPanelShow = true;
		}else if (Time.timeScale == 0) {
			button.gameObject.SetActive (false);
			panelShow.gameObject.SetActive (false);
			Time.timeScale = 1;
			isPanelShow = false;
		}
	}
}
