using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level20 : MonoBehaviour {
//	public Color color;
	[SerializeField]
	private GameObject[] Squares;




	void Awake() {

		//gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 1;
		int x = Random.Range (0,99);

		for (int i = 0; i <= Squares.Length; i++) {

			if(i==x){
				Squares [x].gameObject.tag = "Correct";

				if (SceneManager.GetActiveScene ().name == "20(10x10)") {
					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (1,0.29803f,0.29803f );

				}else if(SceneManager.GetActiveScene().name =="21(10x10)"){

					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (0.7882f,1 ,1 );
				}
				else if(SceneManager.GetActiveScene().name =="22(10x10)"){

					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (0.45882f,0.25098f ,0.4705f );
				}
				else if(SceneManager.GetActiveScene().name =="23(10x10)"){

					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (0.3764f,0.03921f ,0.2549f );
				}
				else if(SceneManager.GetActiveScene().name =="24(10x10)"){

					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (0,0.23960f ,0.03529f );
				}
				else if(SceneManager.GetActiveScene().name =="25(10x10)"){

					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (0.49411f,0.1882f ,0 );
				}
				else if(SceneManager.GetActiveScene().name =="26(10x10)"){

					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (1.14901f,0.9254f ,0.8549f );
				}
				else if(SceneManager.GetActiveScene().name =="27(10x10)"){

					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (0.3254f,0.6627f ,0.5490f );
				}
				else if(SceneManager.GetActiveScene().name =="28(10x10)"){

					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (0.7294f,0.9647f ,1 );
				}
				else if(SceneManager.GetActiveScene().name =="29(10x10)"){

					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (1,0.7333f ,0.73333f );
				}
				else if(SceneManager.GetActiveScene().name =="30(10x10)"){

					Squares [x].GetComponent<SpriteRenderer> ().color = new Color (0.9764f,1 ,0.7882f );
				}



			}
		}



	}
}
