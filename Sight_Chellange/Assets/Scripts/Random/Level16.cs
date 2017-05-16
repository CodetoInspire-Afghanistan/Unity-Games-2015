using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level16 : MonoBehaviour {

	[SerializeField]
	private GameObject[] Squares;




	void Awake() {

		//gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 1;
		int x = Random.Range (0,48);

		for (int i = 0; i <= Squares.Length; i++) {

			if(i==x){
				Squares [x].gameObject.tag = "Correct";
				if (SceneManager.GetActiveScene ().name == "16(7x7)") {
					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (0.6039f,0.6627f,0.35196f );
				}else if(SceneManager.GetActiveScene().name =="17(7x7)"){

					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (0.6980f,0.36862f ,0.5986f );
				}


			}
		}



	}
}