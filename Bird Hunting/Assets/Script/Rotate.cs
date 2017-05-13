using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	
	//public AudioClip Coin_Sound;
	Quaternion rotation;
	
	void Start(){
		
		rotation = transform.localRotation;
		InvokeRepeating("MRotate", 000.1f, 0.01f);
	}
	
	void Update(){

	}
	
	void MRotate(){
		rotation.y += 0.05f;
		//print(rotation);
		if (rotation.y >= 3.2f){
			rotation.y = 0;
		}
		this.transform.rotation = rotation;
	}

}



