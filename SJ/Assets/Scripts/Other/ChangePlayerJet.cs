using UnityEngine;
using System.Collections;

public class ChangePlayerJet : MonoBehaviour {


	private GameObject player;
	public Sprite P1;
	public Sprite P2;
	public Sprite P3;
	public Sprite P4;
    int i;

	// Use this for initialization
	void Start () {
	    }


	public void SpriteP1(){
			i=1;
			ScoreKepper.currentScore -= 800;
		print(i+"text");

	}
		public void SpriteP2(){
			
		this.GetComponent<SpriteRenderer> ().sprite = P2;
		print ("p2");
			ScoreKepper.currentScore -= 500;

		}

	public void SpriteP3(){

			player.GetComponent<SpriteRenderer> ().sprite = P3;
			ScoreKepper.currentScore -= 1000;

		}
		public void SpriteP4(){
		
			player.GetComponent<SpriteRenderer> ().sprite = P4;
			ScoreKepper.currentScore -= 1200;

		}
	}


