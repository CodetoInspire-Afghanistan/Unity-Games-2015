using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bird : MonoBehaviour {

	public  int maxHit;
	private int hit;
	private SceneManage sceneManager;
	public static int killedBirds = 0;
	public AudioClip Shock;
	public GameObject Eggs;
	public GameObject Chicken;

	private ScoreKeeper scoreegg;



	// Use this for initialization
	void Start () {
		scoreegg = GameObject.FindObjectOfType<ScoreKeeper> ();

		killedBirds++;

		sceneManager = GameObject.FindObjectOfType<SceneManage>();
		hit = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D other){
		Destroy (other.gameObject);
		AudioSource.PlayClipAtPoint (Shock, transform.position,1f);
		//gameObject.GetComponent<AudioSource> ().volume = 1f;

		hit++;
		if (hit >= maxHit) {
			killedBirds--;
		
			if (this.gameObject.tag == "Less") {
				Destroy (this.gameObject);
				scoreegg.add(5);

			}

			 if(this.gameObject.tag == "Rusk"){
				Instantiate(Chicken,this.transform.position,Quaternion.identity);
				Destroy (this.gameObject);
				scoreegg.add(10);


			}  if(this.gameObject.tag == "Untagged"){

				Instantiate(Eggs,this.transform.position+new Vector3(0,-1f,0),Quaternion.identity);

				this.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -3f);
				this.GetComponent<PolygonCollider2D>().isTrigger = true;
				Destroy (this.gameObject, 1f);
				scoreegg.add(10);

			}
			if(this.gameObject.tag == "Nest"){
				Destroy(this.gameObject);
				Instantiate(Eggs,this.transform.position,Quaternion.identity);
				Instantiate(Eggs,this.transform.position+new Vector3(0,-1f,0),Quaternion.identity);
				Instantiate(Eggs,this.transform.position+new Vector3(0.200f,-1.50f,0),Quaternion.identity);
				Instantiate(Eggs,this.transform.position+new Vector3(0.40f,-2f,0),Quaternion.identity);
				Instantiate(Eggs,this.transform.position+new Vector3(0.60f,-2.50f,0),Quaternion.identity);
				Instantiate(Eggs,this.transform.position+new Vector3(0.80f,-3f,0),Quaternion.identity);
				Instantiate(Eggs,this.transform.position+new Vector3(1f,-3.50f,0),Quaternion.identity);
				scoreegg.add(70);

				
			}

			sceneManager.BirdDestroyed ();
		}
	}
}
