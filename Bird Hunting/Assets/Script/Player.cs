using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	public float Speed = 20f;
	public GameObject Stones;
	public GameObject Eagle;
	public GameObject FireeStone;
	public GameObject Pile;

	public Text StoneCount;

	public int number =0;


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

		Vector3 PlayerPosition = this.transform.position;
		float mousePosition = Input.mousePosition.x/Screen.width*16;

		if (this.gameObject.tag == "Firee") {
			PlayerPosition.x = Mathf.Clamp (mousePosition, 1.11f, 15f);

		} 
		else if (this.gameObject.tag == "Eagle") {
			PlayerPosition.x = Mathf.Clamp (mousePosition, 1.92f, 14.30f);
			
		}else if (this.gameObject.tag == "Pile") {
			PlayerPosition.x = Mathf.Clamp (mousePosition, 1.54f, 14.64f);
			
		}
		else {
			PlayerPosition.x = Mathf.Clamp (mousePosition, 0.69f, 15.41f);

		}
		this.transform.position = PlayerPosition;


		if (Input.GetMouseButtonDown (0)) {

			number--;
			StoneCount.text=number+"";
			if (number > 0) {

				if(this.gameObject.tag == "Eagle"){
					Instantiate (Eagle, this.transform.position + new Vector3(0,-1f,0), Quaternion.identity);
					this.GetComponent<AudioSource> ().Play ();
				}

				if(this.gameObject.tag == "Firee"){
					Instantiate (FireeStone, this.transform.position + new Vector3(0,1f,0), Quaternion.identity);
					this.GetComponent<AudioSource> ().Play ();
					FireeStone.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, Speed,0);

				}
				if(this.gameObject.tag == "Pile"){
					Instantiate (Pile, this.transform.position + new Vector3(0,2f,0), Quaternion.identity);
					this.GetComponent<AudioSource> ().Play ();
					Pile.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, Speed,0);
					
				}
				if(this.gameObject.tag == "Untagged"){
				Instantiate (Stones, this.transform.position + new Vector3(0,1f,0), Quaternion.identity);
				this.GetComponent<AudioSource> ().Play ();
				Stones.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, Speed,0);

				}
			}
			
		    else {
				ScoreKeeper.score = 0;
				//Application.LoadLevel("Lose Scrin");
                Bird.killedBirds = 0;
                SceneManager.LoadScene("Lose Scrin");

            }
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if (this.gameObject.tag == "Pile" && other.gameObject.tag == "fireS") {
			
				ScoreKeeper.score = 0;

				//Application.LoadLevel("Lose Scrin");
				Bird.killedBirds = 0;
				SceneManager.LoadScene ("Lose Scrin");

		}
	}


}
