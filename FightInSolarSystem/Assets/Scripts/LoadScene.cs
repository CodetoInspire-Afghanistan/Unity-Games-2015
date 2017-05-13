using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {
    private  SceneManager sceneManager;

	void Start() {
        sceneManager=GameObject.FindObjectOfType<SceneManager>();
	}
	// Use this for initialization
	void OnCollisionEnter2D() {
        sceneManager.LoadScene("Lose Screen");
	}
	

}
