using UnityEngine;
using System.Collections;

public class NewLoseCollider : MonoBehaviour {

    private ScoreKeeper scoreKeeper;
   public AudioClip Coin;
	// Use this for initialization
	void Start () {
	scoreKeeper=GameObject.FindObjectOfType<ScoreKeeper>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter2D(Collider2D col){
        AudioSource.PlayClipAtPoint(Coin,transform.position);
		Destroy(col.gameObject);
        scoreKeeper.DecreaseScore();
    }

}
