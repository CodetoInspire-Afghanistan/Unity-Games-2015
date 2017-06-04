using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	private int hits;
	public Sprite[] hitSprites;
	bool isBreakable;
	

	public AudioClip Crack;
	public static int breakableCount = 0;

	public GameObject smokePuff;
	// Use this for initialization
	void Start () {

		hits = 0;
	}
	


	void OnCollisionEnter2D(Collision2D other){

		if (isBreakable) {
			HandleHits ();
		}




	}

	void HandleHits(){
		hits++;
		//SimulateWin ();
		if (hits >= maxHits) {
			breakableCount--;
			GameObject smokePuff2 = Instantiate(smokePuff, this.transform.position, Quaternion.identity) as GameObject;
			smokePuff2.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer>().color;
			Destroy (gameObject);
		//	sceneManager.BreakDestroyed();
		} else {
			int spriteIndex = hits - 1;
			if(hitSprites[spriteIndex]){
				this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
			}
			
			
		}
	}

}
