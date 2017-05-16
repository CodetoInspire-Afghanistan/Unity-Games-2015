using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using ArabicSupport;

public class PersianSearch: MonoBehaviour {

	// Use this for initialization
	public PersianController p;
	public Text t;
	//Text a;
	public InputField x;	
	string[] array = new string[12];
	public Button[] ButtonList;




	void Start () {

		//p = GameObject.Find ("PersianStory") as PersianController;

		array[0]= "مهمان نوازی";
		array[1] = "سیندرلا";
		array[2] ="مهربانی های پدر";
		array[3] = " لاک پشت و خرگوش";
		array[4] = "آیا مرا میشناسید؟";
		array[5] = "پسر بداخلاق";
		array [6] = "طاووس و لاک پشت";
		array[7] = "تاثیر جملات";
		array[8] = "گاوچران هوشیار";
		array[9] = "هدف زندگانی";
		array[10] = "بالشت سحرآمیز";
		array[11] = "پسر شوخ";









	}

	// Update is called once per frame
    void Update () {

		foreach (Button btn in ButtonList) {

			if (btn.GetComponentInChildren<Text> ().text == x.text) {
				btn.gameObject.SetActive (true);
				btn.GetComponent<RectTransform> ().localPosition = new Vector3 (164, -98.8f, 0);

			} 
		}
	}
	public void SearchP(){
		// x.GetComponentInChildren<Text> ().text;  
		x.text = ArabicSupport.ArabicFixer.Fix (x.text); 
		//MyText [i].text = ArabicSupport.ArabicFixer.Fix (MyText[i].text);
		for (int i = 0; i < array.Length; i++) {
			if (array [i].ToString ().Contains (x.text.ToString ())) {

				//t.gameObject.SetActive (true);

				t.text = array [i].ToString ();
				t.text = ArabicFixer.Fix (t.text);
				ButtonList [i].gameObject.SetActive (true);


			}
			ButtonList [i].gameObject.SetActive (false);

		}
	}

			//compare x and text of button
		
	
}



















