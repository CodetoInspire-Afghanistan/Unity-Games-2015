using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level12 : MonoBehaviour {

	[SerializeField]
	private GameObject[] Squares;




	void Awake() {

		//gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 1;
		int x = Random.Range (0,29);

		for (int i = 0; i <= Squares.Length; i++) {

			if(i==x){
				Squares [x].gameObject.tag = "Correct";
				if (SceneManager.GetActiveScene ().name == "12(5x6)") {
					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (0.65490f,0.3764f,1 );
				}else if(SceneManager.GetActiveScene().name =="13(5x6)"){

					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (0.14901f,0.42745f ,0.41568f );
				}



			}
		}



	}
}
