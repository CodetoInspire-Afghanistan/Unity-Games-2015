using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingOption : MonoBehaviour {



	public GameObject Panel;


	void Start(){

	
	}

	public void ShowSettingPanel(){
		
			Panel.SetActive (true);
			
	}


	public void DontShowSettingPanel(){

		Panel.SetActive (false);

	}




}
