using UnityEngine;
using System.Collections;

public class HelicopterController : MonoBehaviour {

	// Use this for initialization
	public GameObject Lazer;
	public AudioClip MissileSound;

	void Start () {
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-1f, 0f);
		InvokeRepeating ("Fair",2f,4f);
	}
	
	// Update is called once per frame
	void Update () {

			
	}
	void Fair(){
		GameObject LazerPre= Instantiate(Lazer,transform.position+new Vector3(0,-0.3f,0),Quaternion.identity) as GameObject;
		LazerPre.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f,-1f);
		AudioSource.PlayClipAtPoint (MissileSound,transform.position);
	}


}
