using UnityEngine;
using System.Collections;

public class ClosePanel : MonoBehaviour {

	public GameObject myPanel;

	//close the panrl
	void OnMouseDown(){
		myPanel.SetActive (false);

	}
}
