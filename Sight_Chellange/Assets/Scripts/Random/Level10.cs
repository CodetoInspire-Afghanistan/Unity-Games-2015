using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level10 : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	private GameObject[] Squares;




	void Awake() {

		//gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 1;
		int x = Random.Range (0,24);

		for (int i = 0; i <= Squares.Length; i++) {

			if(i==x){
				Squares [x].gameObject.tag = "Correct";
				if (SceneManager.GetActiveScene ().name == "10(5x5)") {
					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (0.69803f,0.9803f,1 );
				}else if(SceneManager.GetActiveScene().name =="11(5x5)"){

					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (1,0.53333f ,0.53333f );
				}


			}
		}



	}
}
