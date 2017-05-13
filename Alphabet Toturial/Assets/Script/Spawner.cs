using UnityEngine;
using System.Collections;


public class Spawner : MonoBehaviour {
[SerializeField]
private GameObject []mySp;
[SerializeField]
private Transform balloon;
int numberOF;
[SerializeField]
private float Timer;
private float Timedeley;
float speed;
public string myTag;
int Score;
public GameObject myGameObject;
	public static int newVar;
	public static int newWordTagId;


// Use this for initialization
void Start () {

	Timedeley = Timer;
		if (gameObject.tag == "LatterSpawner") {
			myLetters ();

		}
		if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex==4){
			myLetters ();
		}
}
	//for instantiate word randomly 
public void myLetters(){
		
		numberOF = Random.Range(0,mySp.Length);
		newVar = numberOF;
		if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex==1){
			Vector3 position = new Vector3 (-8f, -2.5f, 0);
			myGameObject = Instantiate (mySp [numberOF], position, transform.rotation) as GameObject;
			myTag = myGameObject.tag;
		}
		if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex==2){
			Vector3 position = new Vector3 (-7.5F ,-1F, 0);
			myGameObject = Instantiate (mySp [numberOF], position, transform.rotation) as GameObject;
			myTag = myGameObject.tag;
		}
	  

}
// 
void Update ()
	{
		if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex==4 ||UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex==3){
			for (int i = 0; i < mySp.Length; i++) {
				if(spawnwords.wordtag[spawnwords.ind]==mySp[i].tag[0]){
					newWordTagId = i;
				}
			
			}
		}
		
	spowner1 ();
		prize ();


} 
	// it for words which we need  more in the game 
void spowner1(){

	Timedeley -= Time.deltaTime;
		int myLetter;
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 4 ||UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 3) {
			int[] currentword = { 1, 2, newWordTagId, 4, newWordTagId, 6, 7, newWordTagId, 9, newWordTagId, 
				11, 12, newWordTagId, 14, newWordTagId, 16, newWordTagId, 18, 19, newWordTagId, 21, newWordTagId, 23, 24, 25, 26 };
			myLetter = currentword [Random.Range (0, currentword.Length - 1)];
		} else {
			int[] A = { 1, 2, newVar, 4, newVar, 6, 7, newVar, 9, newVar, 11, 12, newVar, 14, newVar, 16, newVar, 18, 19, newVar,
				21, newVar, 23, newVar, 25, newVar };
			myLetter = A [Random.Range (0, A.Length - 1)];

		}



		if (Timedeley <= 0 && gameObject.tag != "LatterSpawner" && gameObject.tag !="Candy") {
			

		Vector3 position = new Vector3 (Random.Range (-10f, 10f), transform.position.y, transform.position.z);

			Instantiate (mySp[myLetter],position, transform.rotation);

		Timedeley = Timer;

	}   if(Time.time<5 && Time.time>10){

		Timer = 0.1f; 

	}
}
	//  instaniate prize  with specific time  which has extra score  prize (like candy and pearl )
	void prize(){
		Timedeley -= Time.deltaTime;
		numberOF = Random.Range(0,mySp.Length);
		if (Timedeley <= 0  && gameObject.tag=="Candy"  ) {

			Vector3 position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

			Instantiate (mySp [numberOF], balloon.position, transform.rotation);

			Timedeley = Timer;

		}   if(Time.time<10 && Time.time>20){

			Timer = 0.5f; 

		}
	}

}


