using UnityEngine;
using System.Collections;

public class EnemySpowner : MonoBehaviour {

	// Use this for initialization
	public GameObject Enemy;
	public Transform ChildTo;
	void Start () {
		InvokeRepeating("EnemyCreate",1f,6f);
		//myAnim= GetComponent<Animator>
	}
	
	// Update is called once per frame
	void Update () {

	}
	void EnemyCreate(){

		GameObject EnemyPre = Instantiate (Enemy , transform.position,Quaternion.identity) as GameObject;
		EnemyPre.transform.parent = ChildTo.transform;


	}
}
