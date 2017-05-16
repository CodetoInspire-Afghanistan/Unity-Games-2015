using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {


	public GameObject bubblegift;
	public GameObject Projectile;
	public GameObject Shell;

	public float projectileSpeed = 5f;
	public float fireRate = 0.2f;
	public float padding = 2f;
	public float speed = 15;

	float minX ;
	float maxX ;

	public Transform ProjectilePosition;
	public int health = 110;
	int current_Time = 0;
	int maxTime = 30;
	int maxShell = 2;
	public Text ShellDisplay;
	public bool helpLaser = false;
	int x = 1;
	public Text text;
	public AudioClip LaserSound;

	// Use this for initialization

	void Start () {
		float distance = this.transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		minX = leftMost.x + padding;
		maxX = rightMost.x - padding;
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			Fire ();
		}

		if (SceneManager.GetActiveScene ().name == "Level_04") {
			if (Input.GetKeyDown (KeyCode.B)) {
				//DoubleFair ();
				if (x > 0) {
					InvokeRepeating ("Timer", 0.0001f, 1f);
					InvokeRepeating ("DoubleFair", 0.0001f, 0.2f);
					x -= 1;
					text.text = x + "";
				}
			}

		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;


		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		
		}

		if (SceneManager.GetActiveScene ().name == "Level_02") {

			if (Input.GetKeyDown (KeyCode.R)) {
				if (maxShell > 0) {
					CreateShell ();

				}
			}
		}


		if (SceneManager.GetActiveScene ().name == "Level_03") {
			if (Input.GetKeyDown (KeyCode.S)) {
				if (x > 0) {

					GameObject bubblePre = Instantiate (bubblegift, transform.position, Quaternion.identity) as GameObject;
					bubblePre.transform.position = this.transform.position + Vector3.down;
					x -= 1;
					text.text = x + "";
				}




			}
		}
	}

	// for shooting the projectile from a spiecific location of player jet
	void Fire(){
		GameObject laserPlayer = Instantiate(Projectile,transform.position,Quaternion.identity) as GameObject;
		laserPlayer.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,projectileSpeed);
		laserPlayer.transform.parent = ProjectilePosition;
		AudioSource.PlayClipAtPoint (LaserSound,transform.position,1);

	
	}

	//for checking trigger of gameobject with player
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("RightFair") || other.gameObject.CompareTag("LeftFair")) {
			health = 0;	
			Destroy(gameObject);
            SceneManager.LoadScene("Lose Screen");
		}
		
		if(other.gameObject.CompareTag("EnemyBullet")){
		DecresePlayerDamage (10);
			}
		if (health <= 0) {
			Destroy (gameObject);
				SceneManager.LoadScene ("Lose Screen");
		}
	}


	// for controlling human health
	void DecresePlayerDamage(int amount){
		health -= amount;

		}

	//for controlling the collision of gameobjects with playerjet
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("GiftBullet")) {
			Destroy (col.gameObject);

		}if (col.gameObject.CompareTag ("BrownEnemy") || col.gameObject.CompareTag ("BlackEnemy") || col.gameObject.CompareTag ("RedEnemy")) {
			health = 0;
				Destroy (gameObject);
            SceneManager.LoadScene ("Lose Screen");
		}
			}
		
	void CreateShell(){

		GameObject BombPre = Instantiate(Shell,transform.position,Quaternion.identity) as GameObject;
		BombPre.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,projectileSpeed);
		BombPre.transform.parent = ProjectilePosition;
		maxShell--;
		ShellDisplay.text = maxShell.ToString ();

	}


	// for fire from two position in same type and reffer a gift for playerjet
	void DoubleFair(){

		GameObject laserPlayer = Instantiate(Projectile,transform.position+ new Vector3(0.5f,0,0),Quaternion.identity) as GameObject;
		laserPlayer.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,5);

		GameObject lasrPlayer = Instantiate(Projectile,transform.position+ new Vector3(-0.5f,0,0),Quaternion.identity) as GameObject;
		lasrPlayer.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,projectileSpeed);

	}


	//calculate a limit time for doublfiring
	void Timer(){
		current_Time += 1;
		print(current_Time);
		if(current_Time==maxTime){
			CancelInvoke("DoubleFair");
			CancelInvoke("Timer");

		}

	}
}