using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BigJetSpowner : MonoBehaviour {

	// Use this for initialization
	public GameObject BigJet;
	public GameObject Layser;
	public GameObject Bomb;
	public GameObject SmallEnemiesSpowner;
	public static bool bigJetIsDead= false;


	//public 

	public int health = 300;
	void Start () {

		InvokeRepeating ("fire", 2f,3f);
	}


	void Update(){

		
		if (ScoreKepper.currentScore >= 300) {
			BigJet.gameObject.SetActive (true);
			SmallEnemiesSpowner.SetActive (false);

		}	

	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("PlayerBullet")) {	
			
			DecreseHealth (10);
			if (health <= 0) {
                ScoreKepper.currentScore += 200;
                SceneManager.LoadScene("Missions");
				Destroy (BigJet.gameObject);
				bigJetIsDead = true;


			}
		}
		if (col.gameObject.CompareTag ("Shell")) {
			health = 0;
			Destroy (gameObject);
            ScoreKepper.currentScore += 200;
			bigJetIsDead = true;
            SceneManager.LoadScene("Missions");


        }
	}
	void DecreseHealth(int amount){
		health -= amount;

	}

	void CreteBigJet(){
		GameObject BigPre = Instantiate (BigJet,Vector3.zero,Quaternion.identity) as GameObject;


	}


	void fire(){
		GameObject layser = Instantiate(Layser,transform.position+new Vector3(1.5f,-1,0),Quaternion.identity)as GameObject;
		layser.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,-10f);

		GameObject laser = Instantiate(Layser,transform.position+new Vector3(2f,-0.5f,0),Quaternion.identity)as GameObject;
		laser.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,-10f);

		GameObject laysr = Instantiate(Layser,transform.position+new Vector3(3f,-0.5f,0),Quaternion.identity)as GameObject;
		laysr.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,-10f);

		GameObject layer = Instantiate(Layser,transform.position+new Vector3(-1.5f,-1,0),Quaternion.identity)as GameObject;
		layer.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,-10f);

		GameObject lyser = Instantiate(Layser,transform.position+new Vector3(-2f,-0.5f,0),Quaternion.identity)as GameObject;
		lyser.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,-10f);

		GameObject layseer = Instantiate(Layser,transform.position+new Vector3(-3f,-0.5f,0),Quaternion.identity)as GameObject;
		layseer.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,-10f);

	}



}

