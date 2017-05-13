using UnityEngine;
using System.Collections;

public class Subtract : MonoBehaviour {
    private  ScoreKeeper scoreKeeper;
    public GameObject stone;
	void Start() {
        scoreKeeper=GameObject.FindObjectOfType<ScoreKeeper>();
	}
    void OnCollisionEnter2D() {
        if (stone)
	scoreKeeper.subtract(1);
    }
}
