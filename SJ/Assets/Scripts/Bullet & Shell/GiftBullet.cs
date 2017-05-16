using UnityEngine;
using System.Collections;

public class GiftBullet : MonoBehaviour {

	// Use this for initialization
	public GameObject Player;
	void Start () {
	
	}


	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ( "GiftBullet")) {
			Instantiate (gameObject, Player.transform.position + Vector3.up, Quaternion.identity);
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2(0,1);
			//gift.transform.parent = ProjectilePosition;

		}

	}
}
