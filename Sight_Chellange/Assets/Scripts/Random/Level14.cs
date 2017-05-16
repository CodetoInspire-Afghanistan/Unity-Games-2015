using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level14 : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	private GameObject[] Squares;




	void Awake() {

		//gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 1;
		int x = Random.Range (0,36);

		for (int i = 0; i <= Squares.Length; i++) {

			if(i==x){
				Squares [x].gameObject.tag = "Correct";
				if (SceneManager.GetActiveScene ().name == "14(6x6)") {
					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (0.149019f,0.04313f,0.04313f );
				}else if(SceneManager.GetActiveScene().name =="15(6x6)"){

					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (0.74901f,0.39607f ,0.39607f );
				}




			}
		}



	}
}
