using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	// Use this for initialization
    public GameObject Lazer;
   public float time= 0.0079f;
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        float myTime = Random.Range(0f,1f);
        if(myTime<=time) {
			//InvokeRepeating("Fire", 1f, 0.01f);
            Fire();
		}
	}

void Fire(){
   GameObject LazerMove= Instantiate(Lazer,this.transform.position,Quaternion.identity) as GameObject;
    LazerMove.GetComponent<Rigidbody2D>().velocity= new Vector2(0,-2f);
}
}
