using UnityEngine;
using UnityEngine.UI;
using ArabicSupport;
using System.Collections;

public class PersianController : MonoBehaviour {


	// Use this for initialization
	public int size;
	public Text[] MyText;

	void Start () {
	
		ChangeToP ();
//		for (int i = 0; i <= size; i++) {
//			MyText [i].text = ArabicSupport.ArabicFixer.Fix (MyText[i].text);
//		}
//

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ChangeToP(){
		for (int i = 0; i <= size; i++) {
			MyText [i].text = ArabicSupport.ArabicFixer.Fix (MyText[i].text);
		}


	}
}