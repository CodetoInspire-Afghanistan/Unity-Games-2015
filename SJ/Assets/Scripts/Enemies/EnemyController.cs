using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour {

	// Use this for initialization


	public int health = 120;
	private ScoreKepper scorekepper;
	public GameObject Explosion;
	public GameObject EnemyLaser;
	public float FireDelay= 1f;
    public float createDelay= 9f;






	void Start () {
		scorekepper = GameObject.FindObjectOfType<ScoreKepper> ();

	
		InvokeRepeating ("CreateEnemy",8f,createDelay);
		InvokeRepeating ("EnemyFair", 5f, FireDelay);
		
	}


	void Update () {




	}

	void OnCollisionEnter2D(Collision2D  other){
		if(gameObject.CompareTag("1 Hit")){
			scorekepper.IncreaseScore (5);
			Destroy(gameObject);
	


		}else if(gameObject.CompareTag ("2 Hits")){
			DecreaseDamage (60);
			if (health<= 0){
				Destroy(gameObject);
				scorekepper.IncreaseScore (10);
			}

		}else if(gameObject.CompareTag ("3 Hits")){
			DecreaseDamage (40);
			if (health<= 0){
				Destroy(gameObject);
				scorekepper.IncreaseScore (15);
			}

		}


	}




	public void DecreaseDamage(int amount){
		health -= amount;
		}


	public void EnemyExplosion(){
		GameObject ExplosionPre= Instantiate (Explosion,transform.position,Quaternion.identity) as GameObject;
	} 


	void EnemyFair(){

		GameObject EnemyLaserPre = Instantiate (EnemyLaser, transform.position+Vector3.down, Quaternion.identity) as GameObject;
		EnemyLaserPre.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f,-10f);
	
	}
}