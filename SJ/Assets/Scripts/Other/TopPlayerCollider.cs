using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TopPlayerCollider : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			Destroy (col.gameObject);
			SceneManager.LoadScene ("Missions");
		}

	}

}
