using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorestBullets : MonoBehaviour {

		//public  GameObject m11;
		public  GameObject RedB;
		public  GameObject BlackB;
		public  GameObject BrownB;
		public  GameObject Missile;
		public GameObject Player;
	public Text numberOfshell;

		int maxMissiles= 6;


		void OnCollisionEnter2D(Collision2D col){
		
			Destroy (gameObject);
		}
			//  Destroy(col.gameObject);
	void Update(){

	}
	void OnMouseDown(){
		if(gameObject.tag == "RedBullet") {
			GameObject laserPlayer = Instantiate(RedB, Player.transform.position, Quaternion.identity) as GameObject;
			laserPlayer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20f);
		}

		if(gameObject.tag == "BlackBullet") {

			GameObject laserPlayer = Instantiate(BlackB, Player.transform.position, Quaternion.identity) as GameObject;
			laserPlayer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20f);
		}
	 if(gameObject.tag == "BrownBullet") {

			GameObject laserPlayer = Instantiate(BrownB, Player.transform.position, Quaternion.identity) as GameObject;
			laserPlayer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20f);

		}
	if(gameObject.tag == "Shell") {
			if(maxMissiles>0){
				GameObject laserPlayer = Instantiate(Missile, Player.transform.position, Quaternion.identity) as GameObject;
				laserPlayer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20f);
				maxMissiles--;
				numberOfshell.text = maxMissiles.ToString();
				//print(maxMissiles);
			}

		}
	}
}
