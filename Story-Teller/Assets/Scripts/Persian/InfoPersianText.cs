using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoPersianText : MonoBehaviour {

	// Use this for initialization

	public Text[] MyText;
	void Start () {
		for(int x=0;x<=MyText.Length;x++){
			MyText [x].text = ArabicSupport.ArabicFixer.Fix (MyText[x].text);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
