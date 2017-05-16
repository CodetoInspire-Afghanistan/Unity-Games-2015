using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomSquare : MonoBehaviour {
	[SerializeField]
	private GameObject[] Squares;




	void Awake() {

		//gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 1;
		int x = Random.Range (0,1);

		for (int i = 0; i <= Squares.Length; i++) {

			if(i==x){
				Squares [x].gameObject.tag = "Correct";
			//	Squares [x].GetComponent<SpriteRenderer> ().color = new Color(1,1,1);
				Squares [x].GetComponent<SpriteRenderer> ().color = new Color (1,1,1,2);

			}
		}

	


	}
	//2=0,1
	//3=0,2
	//4=0,3
	//5=0,4
	//6=0,5

	void OnMouseDown(){
		

				print ("score1");
			}


}
