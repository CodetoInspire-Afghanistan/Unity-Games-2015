using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AutoType : MonoBehaviour {
	
		public Text text;
		public string myString = "";
		public float typeDelay= 0.001f;
		void Start () {

			StartCoroutine ("TypeText");

		}

		// Update is called once per frame
		void Update () {

		}

		IEnumerator TypeText(){
			foreach (char letter in myString.ToCharArray()) {
				text.text += letter;
				yield return 0;
				yield return new WaitForSeconds (typeDelay);
			}

		}
	}