using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeyController : MonoBehaviour {

	public Button keyImage;
	public GameObject Key;

	// Use this for initialization
	void Start () {
		keyImage.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(){
		keyImage.gameObject.SetActive (true);
		Key.SetActive (false);
	}
}
