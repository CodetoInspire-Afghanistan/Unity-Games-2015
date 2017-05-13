using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score : MonoBehaviour {
	
	public static int scoreSta=0;
	[SerializeField ]
	private Text Scoretext;

	void Update(){
		//display the score on the screen
		Scoretext.text=scoreSta.ToString();
	}

}
