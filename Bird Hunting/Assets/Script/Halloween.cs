using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Halloween : MonoBehaviour {
	public GameObject Fire;
	public AudioClip lost;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D other){
		Destroy (other.gameObject);
		AudioSource.PlayClipAtPoint (lost, transform.position, 1f);

		Instantiate (Fire, this.transform.position+new Vector3(0,0,-15), Quaternion.identity);
		//Destroy (gameObject);

		gameObject.SetActive (false);

		Invoke ("Call", 3f);
	}
	void Call(){
		ScoreKeeper.score = 0;
		//print ("call");
		//Application.LoadLevel ("Lose Scrin");
        Bird.killedBirds = 0;
        SceneManager.LoadScene("Lose Scrin");

        Destroy (gameObject);

	}
}
