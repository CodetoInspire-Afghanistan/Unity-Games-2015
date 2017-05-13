using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D D){
		
		Destroy(gameObject);

	}}