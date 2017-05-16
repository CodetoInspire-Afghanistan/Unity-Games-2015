using UnityEngine;
using System.Collections;

public class HorizontalJet : MonoBehaviour {

	// Use this for initialization
	public GameObject Missile;
	//public AudioClip MissileSound;
	public int health = 100;
	void Start () {
		CreatLandScipJet ();
		InvokeRepeating ("Fair",5f,2.6f);
	}
	
	// Update is called once per frame
	void Update () {

        }


	void OnTriggerEnter2D(Collider2D col){
//		

		 if (col.gameObject.CompareTag ("Shell")) {
			Destroy (gameObject);
			ScoreKepper.currentScore += 125;

		}

	}

	void CreatLandScipJet(){
		
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-1f,0);
	}

	void Fair(){

		GameObject MissilePre = Instantiate (Missile , transform.position+new Vector3(0,-0.3f,0),Quaternion.identity) as GameObject;
		MissilePre.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-1f,-1f);

	}



	void DecreseDamage(int amount){
		health -= amount;

	}
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.CompareTag("Shell")){
			Destroy (gameObject);
		}

	}
	void OnTriggerEnter2D(){
		Destroy (gameObject);
	}


}
