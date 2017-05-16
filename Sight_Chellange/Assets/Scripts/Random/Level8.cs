using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level8 : MonoBehaviour {

	[SerializeField]
	private GameObject[] Squares;




	void Awake() {

		//gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 1;
		int x = Random.Range (0,19);

		for (int i = 0; i <= Squares.Length; i++) {

			if(i==x){
				Squares [x].gameObject.tag = "Correct";
				if (SceneManager.GetActiveScene ().name == "8(4x5)") {
					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (1,0.81960f,1 );
				}else if(SceneManager.GetActiveScene().name =="9(4x5)"){

					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (0.46274f,0.46274f ,0.46274f );
				}
			

			}
		}



	}
}
