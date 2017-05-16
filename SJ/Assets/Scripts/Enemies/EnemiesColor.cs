using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemiesColor : MonoBehaviour {

	public GameObject Explosion;
	public GameObject EnemyLaser;

	private EnemyController enemyController;
	void Start () {
		enemyController = GameObject.FindObjectOfType<EnemyController> ();
		InvokeRepeating ("EnemyFire",1f,3f);
	}
	

	void Update () {
        if(ScoreKepper.currentScore >= 1200) {
      SceneManager.LoadScene("Missions");

        }
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("RedBullet")) {
			if (gameObject.CompareTag ("RedEnemy")) {

				Destroy (gameObject);
				ScoreKepper.currentScore += 20;
			}

	}else if (col.gameObject.CompareTag ("BlackBullet")) {
			if (gameObject.CompareTag ("BlackEnemy")) {

				Destroy (gameObject);
				ScoreKepper.currentScore += 20;


			}

			} else if (col.gameObject.CompareTag ("BrownBullet")) {
				if (gameObject.CompareTag ("BrownEnemy")) {
					Destroy (gameObject);
			
				ScoreKepper.currentScore += 20;

				}
			}

}


	void EnemyExplosion(){
		GameObject ExplosionPre= Instantiate (Explosion,transform.position,Quaternion.identity) as GameObject;
	} 


	void EnemyFire(){

		GameObject EnemyLaserPre = Instantiate (EnemyLaser, transform.position+Vector3.down, Quaternion.identity) as GameObject;
		EnemyLaserPre.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f,-10f);


}
}




