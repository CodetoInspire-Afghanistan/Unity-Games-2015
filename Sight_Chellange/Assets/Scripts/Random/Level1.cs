using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	private GameObject[] Squares;
	//public Color color;
	//private bool helpDone=false;
	//public GameObject Tick;


	void Awake ()
	{

		//gameObject.GetComponent<SpriteRenderer> ().sortingOrder = 1;
		int x = Random.Range (1, 2);

		for (int i = 0; i <= Squares.Length; i++) {

			if (i == x) {
				Squares [x].gameObject.tag = "Correct";
				Squares [x].GetComponent<SpriteRenderer> ().color = new Color (0.09019f, 0.6190f, 1);
				//Squares [x].transform.position= Vector3.right;
//				if (helpDone) {
//					Instantiate (Tick, Squares [x].transform.position, Quaternion.identity);
//				}

			}
		}
	}

	void Update(){
		

	}
//	public void Helping(){
//		helpDone = true;
//
//	}
}
	


	

