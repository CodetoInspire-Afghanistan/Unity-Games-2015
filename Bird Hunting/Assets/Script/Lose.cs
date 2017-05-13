using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Egg") {
			Destroy (other.gameObject);
		}
		else if (other.gameObject.tag == "fireS") {
			Destroy (other.gameObject);
		}
		else {

			//Application.LoadLevel ("Lose Scrin");
            Bird.killedBirds = 0;
            SceneManager.LoadScene("Lose Scrin");

        }

	}
	void OnCollisionEnter2D(Collision2D other){

	}

}
