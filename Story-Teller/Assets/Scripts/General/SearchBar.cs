using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;


public class SearchBar : MonoBehaviour {

	// Use this for initialization

	public Text t;
	public InputField x;	
	string[] array = new string[12];
	public Button[] ButtonList;




	void Start () {

		array[0]= "Tortoise and Hare";
		array[1] = "Cinderella";
		array[2] = "Do You Know Who I am?";
		array[3] = "Immoral Boy";
		array[4] = "Peacock and Tortoise";
		array[5] = "Witty Boy";
		array[6] = "Effect of Sentences";
		array[7] = "Smart Cowboy";
		array[8] = "Purpose of life";
		array[9] = "The Pillow Fairy";
		array[10] = "Hospitality";
		array[11] = "Kindness of fathers";
	






	

	}

	// Update is called once per frame
	void Update () {

		foreach (Button btn in ButtonList) {

			if (btn.GetComponentInChildren<Text> ().text == t.text) {
				btn.gameObject.SetActive (true);
				btn.GetComponent<RectTransform> ().localPosition = new Vector3 (164, -98.8f, 0);

			}
		}
	
	}




		public void Search(){
		
			for (int i = 0; i < array.Length; i++) {
				if(array[i].ToString().Contains(x.text.ToString(),StringComparison.OrdinalIgnoreCase )){
					t.text = array[i].ToString();

				}
				ButtonList [i].gameObject.SetActive (false);




			//compare x and text of button
		}

		}
	}




















