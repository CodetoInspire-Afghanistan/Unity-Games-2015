using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerDamage : MonoBehaviour {

	// Use this for initialization
	private PlayerController playercontroller;

	public Sprite Health100;
	public Sprite Health90;
	public Sprite Health80;
	public Sprite Health70;
	public Sprite Health60;
	public Sprite Health50;
	public Sprite Health40;
	public Sprite Health30;
	public Sprite Health20;
	public Sprite Health10;
	public Sprite Health0;

	public Text showHeatlh;

	// Use this for initialization
	void Start () {
		playercontroller = GameObject.FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(playercontroller.health==100){
			gameObject.GetComponent<SpriteRenderer> ().sprite = Health100;
			showHeatlh.text = "100%" + "";
		}else if(playercontroller.health==90){
			gameObject.GetComponent<SpriteRenderer> ().sprite = Health90;
			showHeatlh.text = "90%" + "";
		}else if(playercontroller.health==80){
			gameObject.GetComponent<SpriteRenderer> ().sprite = Health80;
			showHeatlh.text = "80%" + "";
		}else if(playercontroller.health==70){
			gameObject.GetComponent<SpriteRenderer> ().sprite = Health70;
			showHeatlh.text = "70%" + "";
		}else if(playercontroller.health==60){
			gameObject.GetComponent<SpriteRenderer> ().sprite = Health60;
			showHeatlh.text = "60%" + "";
		}else if(playercontroller.health==50){
			gameObject.GetComponent<SpriteRenderer> ().sprite = Health50;
			showHeatlh.text = "50%" + "";
		}else if(playercontroller.health==40){
			gameObject.GetComponent<SpriteRenderer> ().sprite = Health40;
			showHeatlh.text = "40%" + "";
		}else if(playercontroller.health==30){
			gameObject.GetComponent<SpriteRenderer> ().sprite = Health30;
			showHeatlh.text = "30%" + "";
		}else if(playercontroller.health==20){
			gameObject.GetComponent<SpriteRenderer> ().sprite = Health20;
			showHeatlh.text = "20%" + "";
		}else if(playercontroller.health==10){
			gameObject.GetComponent<SpriteRenderer> ().sprite = Health10;
			showHeatlh.text = "10%" + "";
		}else if(playercontroller.health==0){
			gameObject.GetComponent<SpriteRenderer> ().sprite = Health0;
			showHeatlh.text = "0%" + "";
		}
			
	}

}


