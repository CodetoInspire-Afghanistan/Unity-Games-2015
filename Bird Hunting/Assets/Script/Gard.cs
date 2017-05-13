using UnityEngine;
using System.Collections;

public class Gard : MonoBehaviour {
	bool moveRight = true;
	public float speed = 15f;
	public float width = 10f;
	public GameObject FireeStone;

	public float min = 2f;
	public float max = 4f;


	float maxX;
	float minX;

	// Use this for initialization
	void Start () {
		float distence = this.transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distence));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distence));
		minX = leftMost.x;
		maxX = rightMost.x;

		if (this.gameObject.tag == "Definder") {
			InvokeRepeating ("Firee", Random.Range(min, max),Random.Range(min,max));
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if (moveRight) {
			transform.position += Vector3.right * Time.deltaTime * speed;
		} else {
			transform.position += Vector3.left * Time.deltaTime * speed;
		}
		float rightEdgeOfFormation = transform.position.x + 1.2f;
		float leftEdgeOfFormation = transform.position.x - 1.2f;
		if (rightEdgeOfFormation > maxX) {
			moveRight = false;
		} else if (minX > leftEdgeOfFormation) {
			moveRight = true;
			
		}
	



	}

	void Firee(){
	GameObject Layser = Instantiate(FireeStone, this.transform.position + new Vector3(0,-2f,0), Quaternion.identity) as GameObject;
		Layser.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -1f, 0);
	}

	
	

	void OnCollisionEnter2D(Collision2D other){

		Destroy (other.gameObject);
	}
}
