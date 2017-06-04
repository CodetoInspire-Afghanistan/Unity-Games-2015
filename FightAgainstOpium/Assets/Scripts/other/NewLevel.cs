using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NewLevel : MonoBehaviour {
	public AudioClip win;
	public string name;
	void loadName(){
		UnityEngine.SceneManagement.SceneManager.LoadScene(name);

	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			AudioSource.PlayClipAtPoint (win,transform.position,1f);
			Invoke ("loadName",4f);
		}
	
	}
}
