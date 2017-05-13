using UnityEngine;
using System.Collections;

public class Gift : MonoBehaviour {
	public GameObject giftSmoke;
	public AudioClip Prize;
	private ScoreKeeper scoreKeep;

	// Use this for initialization
	void Start () {

		scoreKeep = GameObject.FindObjectOfType<ScoreKeeper> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D other){
		Destroy (other.gameObject);
		AudioSource.PlayClipAtPoint (Prize, transform.position, 1f);

		Instantiate(giftSmoke,this.transform.position+new Vector3(0,0,-13),Quaternion.identity);
		//giftSmoke.GetComponent<ParticleSystem> ().startColor = this.GetComponent<SpriteRenderer> ().color;
		Destroy (this.gameObject);
		scoreKeep.add (5);
	}
}
