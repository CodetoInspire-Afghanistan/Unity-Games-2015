using UnityEngine;
using System.Collections;

public class DontBreakeBottle : MonoBehaviour {

    public  AudioClip Break_Sound;
    private ScoreKeeper scoreKeeper;

    void Start(){
        scoreKeeper=GameObject.FindObjectOfType<ScoreKeeper>();
    }
	void OnCollisionEnter2D(Collision2D col){
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(Break_Sound,this.transform.position);
        scoreKeeper.DecreaseScore();

    }
}
