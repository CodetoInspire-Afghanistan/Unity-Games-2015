using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using ArabicSupport;

public class LOSMainButton: MonoBehaviour {

	// Use this for initialization
	public Text[] myText;

	void Start () {


		for (int i = 0; i <= myText.Length; i++) {
			myText [i].text = ArabicSupport.ArabicFixer.Fix (myText [i].text);
		}

	}



}