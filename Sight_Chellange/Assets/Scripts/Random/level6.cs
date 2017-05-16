using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class level6 : MonoBehaviour {

	[SerializeField]
	private GameObject[] Squares;




	void Awake() {

		//gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 1;
		int x = Random.Range (0,15);

		for (int i = 0; i <= Squares.Length; i++) {

			if(i==x){
				Squares [x].gameObject.tag = "Correct";
				if (SceneManager.GetActiveScene ().name == "6(4x4)") {
					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (0.113725f,1 ,0.870588f );
				}else if(SceneManager.GetActiveScene().name =="7(4x4)"){

					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (1,0.05098f ,0.05098f );
				}
			}
		}



	}
}
