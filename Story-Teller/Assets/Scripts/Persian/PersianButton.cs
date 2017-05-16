using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using ArabicSupport;

public class PersianButton : MonoBehaviour {

	// Use this for initialization
	public Text[] MyText;
	void Start () {

		for(int x=0;x<7;x++){
			MyText [x].text = ArabicSupport.ArabicFixer.Fix (MyText[x].text);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
