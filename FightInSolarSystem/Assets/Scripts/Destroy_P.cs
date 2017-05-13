using UnityEngine;
using System.Collections;

public class Destroy_P : MonoBehaviour {
	private  Heart heart;

	void Start() {
        heart=GameObject.FindObjectOfType<Heart>();
	}

	void OnCollisionEnter2D() {
		if (Heart.p == -1) {
			UnityEngine.SceneManagement.SceneManager.LoadScene("Lose Screen");

		}
			else if (Heart.p>=0){
				heart.subtract1(1);
			}

    }
}