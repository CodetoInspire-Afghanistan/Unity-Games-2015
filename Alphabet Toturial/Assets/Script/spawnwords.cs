using UnityEngine;
using System.Collections;


public class spawnwords : MonoBehaviour {
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
	public static int ind;
	public static string wordtag;
	public GameObject myGameObject;
	public static int newVar;
	// Use this for initialization
	void Start () {
		Timedeley = Timer;
		myLetters ();
	}
	// instantiate word randomly in level 3 and 4
	public void myLetters(){

		numberOF = Random.Range(0,mySp.Length);
		newVar = numberOF;
		if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex==3){
			Vector3 position = new Vector3 (-5f,-4f, transform.position.z);
			myGameObject = Instantiate (mySp [numberOF], position, transform.rotation) as GameObject;
			myTag = myGameObject.tag;
			wordtag = myTag;
		}
		if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex==4){
			Vector3 position = new Vector3 (-4.75f,-1.38f, transform.position.z);
			myGameObject = Instantiate (mySp [numberOF], position, transform.rotation) as GameObject;
			myTag = myGameObject.tag;
			wordtag = myTag;
		}
	

	}

	void Update ()
	{		
		//for destroy word which touched and instantiate new word by calling my letter method
		if (WordTouching.myString == mySp[numberOF].tag ||touching.myString == mySp[numberOF].tag) {
			WordTouching.myString = "";
			touching.myString = "";
			Destroy (myGameObject);
			myLetters ();
			}
	


	}


}


