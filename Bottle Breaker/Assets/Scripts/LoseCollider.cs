using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
		
	void OnTriggerEnter2D(Collider2D other) {
        Destroy(other.gameObject);
        if(ScoreKeeper.score>0){
            ScoreKeeper.score=0;
        }
        Application.LoadLevel("Stone Fall Lose Screen");

    }
      }

