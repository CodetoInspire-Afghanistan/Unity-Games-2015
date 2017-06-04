using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoorCollider : MonoBehaviour {

	public GameObject panel;
	public Sprite OpenedDoor;



	public void OpenDoor(){
		gameObject.GetComponent<SpriteRenderer> ().sprite = OpenedDoor;

	}
	void Update(){
		if(gameObject.GetComponent<SpriteRenderer> ().sprite == OpenedDoor){

			gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		}
	}
	public void OpenPanel(){
		panel.gameObject.SetActive (true);
	}
	public void ClosePanel(){
		panel.gameObject.SetActive (false);

	}
	void OnCollisionEnter2D(Collision2D col){
		OpenPanel();

	}
}
