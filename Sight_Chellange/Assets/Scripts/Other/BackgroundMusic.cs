using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {

	// Use this for initialization
	private static bool IsPlay=false;
	void Start () {
		if (IsPlay) {
			Destroy (gameObject);
		} else {
			GameObject.DontDestroyOnLoad(gameObject);
			IsPlay = true;
		}

	}
	
	// Update is called once per frame
	void Update () {
		

	}



}
