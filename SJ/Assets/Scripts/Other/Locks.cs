using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Locks : MonoBehaviour {

	public string sceneName;
	public Sprite Unlock;


	// Use this for initialization 
	void Start(){

		if (ScoreKepper.currentScore >=500 ) {

			if (gameObject.CompareTag ("Lock2")) {
				gameObject.GetComponent<BoxCollider2D> ().enabled = true;
				gameObject.GetComponent<SpriteRenderer> ().sprite = Unlock;
			}
		}if (ScoreKepper.currentScore >= 1200) {

				if (gameObject.CompareTag ("Lock3")) {
					gameObject.GetComponent<BoxCollider2D> ().enabled = true;
                    gameObject.GetComponent<SpriteRenderer> ().sprite = Unlock;
				}
			}if (ScoreKepper.currentScore >= 1800) {

				if (gameObject.CompareTag ("Lock4")) {
					gameObject.GetComponent<BoxCollider2D> ().enabled = true;
                    gameObject.GetComponent<SpriteRenderer> ().sprite = Unlock;
				}

			}
			}

	// for clicking on each unlock level and going on another level
	void OnMouseDown(){

		SceneManager.LoadScene(sceneName);
	}
}
