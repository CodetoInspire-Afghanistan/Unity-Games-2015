using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	public GameObject Explosion;
	public AudioClip ExpSound;
	public Sprite death;


	void Start(){
		Explosion.SetActive (false);
	}


	void Update () {
	
		if (Input.GetKeyDown (KeyCode.N)) {
			Destroy (gameObject);
		} 


	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Player")) {
			Explosion.SetActive (true);
			AudioSource.PlayClipAtPoint (ExpSound, transform.position);
			Destroy (gameObject);
			other.gameObject.GetComponent<SpriteRenderer> ().sprite = death;
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Lose");

		}
	}


}
