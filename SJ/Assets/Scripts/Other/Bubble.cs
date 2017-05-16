using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour {

	// Use this for initialization
	public GameObject Player;
	int time=0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(transform.localScale==new Vector3(2.378549f, 1.90143f,1f)){
			this.transform.position = Player.transform.position+Vector3.down;

		}
	
	}
	// for checking the collision of gameobjects with bubble
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("Player")) {
			InvokeRepeating ("Time", 0.00001f, 1f);
			transform.localScale = new Vector3 (2.378549f, 1.90143f, 1f);
			this.GetComponent<Rigidbody2D> ().gravityScale = 0;
		}
		else if (col.gameObject.CompareTag("BrownEnemy")){
			Destroy (col.gameObject);
			ScoreKepper.currentScore += 20;


		}  if (col.gameObject.CompareTag("BlackEnemy")){
			Destroy (col.gameObject);
			ScoreKepper.currentScore += 20;

		}  if (col.gameObject.CompareTag("RedEnemy")){
			Destroy (col.gameObject);
			ScoreKepper.currentScore += 20;

		}  
	}

	void Time(){
		time++;
		if (time == 30) {
			Destroy (gameObject);
		}
	}
}
