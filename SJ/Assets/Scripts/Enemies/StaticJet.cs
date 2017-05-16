using UnityEngine;
using System.Collections;

public class StaticJet : MonoBehaviour {
	
	public GameObject EnemyLaser;
	public int health = 300;
	public Transform EnemyLaserPosition;




	void Start () {
		InvokeRepeating ("Fair",2f,3f);
	}
	

	void Update () {




			//Debug.Log (myRandom);

	}

	void Fair(){
		if(gameObject.CompareTag("LeftStaticJet")){
			GameObject LaserPre = Instantiate (EnemyLaser,transform.position+Vector3.down+Vector3.right,Quaternion.identity) as GameObject;
			LaserPre.transform.parent = EnemyLaserPosition.transform;
			LaserPre.GetComponent<Rigidbody2D> ().velocity = new Vector2 (4f,-8f);

		}else if (gameObject.CompareTag("RightStaticJet")){
			GameObject LaserPre = Instantiate (EnemyLaser,transform.position+Vector3.down+Vector3.left,Quaternion.identity) as GameObject;
			LaserPre.transform.parent = EnemyLaserPosition.transform;
			LaserPre.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-4f,-8f);

		}
	}


	void OnCollisionEnter2D(Collision2D col){
		DecreseStaticJetDamage (10);
		if (health <= 0) {
			Destroy (gameObject);
			ScoreKepper.currentScore += 50;
		}
	}
	void DecreseStaticJetDamage(int amount){
		health -= amount;

	}

}
