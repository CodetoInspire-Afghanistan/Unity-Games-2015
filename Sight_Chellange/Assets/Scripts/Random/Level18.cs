using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level18 : MonoBehaviour {

	[SerializeField]
	private GameObject[] Squares;




	void Awake() {

		//gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 1;
		int x = Random.Range (0,63);

		for (int i = 0; i <= Squares.Length; i++) {

			if(i==x){
				Squares [x].gameObject.tag = "Correct";
				if (SceneManager.GetActiveScene ().name == "18(8x8)") {
					Squares [x].GetComponent<SpriteRenderer> ().color = new Color( 0.0549f,0.1764f,0.3333f );
				}else if(SceneManager.GetActiveScene().name =="19(8x8)"){

					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (1,0.10980f ,0.45882f );
				}

			}
		}



	}
}
