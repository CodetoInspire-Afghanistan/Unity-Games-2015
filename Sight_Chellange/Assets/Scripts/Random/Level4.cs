using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level4 : MonoBehaviour {

	[SerializeField]
	private GameObject[] Squares;




	void Awake() {

		//gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 1;
		int x = Random.Range (0,8);

		for (int i = 0; i <= Squares.Length; i++) {

			if(i==x){
				Squares [x].gameObject.tag = "Correct";
				if (SceneManager.GetActiveScene ().name == "4(3x3)") {
					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (1,0.360784f ,0.64705f );
				}else if(SceneManager.GetActiveScene().name =="5(3x3)"){
					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (1,0.61568f ,0.96078f );
				}

			


			}
		}



	}
}
