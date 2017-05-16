using UnityEngine;
using System.Collections;

public class TankBylletSpowner : MonoBehaviour {

	// Use this for initialization
	public GameObject Laser; 
	public Transform Parent;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Fire",0.5f,1f);
	}

	//for shooting the fire from tank
	void Fire(){

		GameObject LaserPre = Instantiate (Laser,this.transform.position,Quaternion.identity) as GameObject;
		LaserPre.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-1f,1f);
		LaserPre.transform.parent = Parent;
	}
}
