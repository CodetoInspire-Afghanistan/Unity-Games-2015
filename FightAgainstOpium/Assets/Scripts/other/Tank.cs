using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour {

	// Use this for initialization
	public GameObject Shell;
	public float Fire_Rate;
	public Transform fire;
	void Start () {
		InvokeRepeating ("Fire",5f,Fire_Rate);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Fire(){

		GameObject Missile = 	Instantiate(Shell,fire.position,Quaternion.identity) as GameObject;
	
	}
}
