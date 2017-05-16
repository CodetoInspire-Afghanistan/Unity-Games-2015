using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour {

	[SerializeField]
	private GameObject[] Squares;




	void Awake() {

		//gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 1;
		int x = Random.Range (0,3);

		for (int i = 0; i <= Squares.Length; i++) {

			if(i==x){
				Squares [x].gameObject.tag = "Correct";
				if (SceneManager.GetActiveScene ().name == "2(2x2)") {
					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (0.78823f,0.49411f ,0.30980f );
				}else if(SceneManager.GetActiveScene().name =="3(2x2)"){
					
					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (1,0.9215f ,0.705f );
				}

			}
		}



	}
}
