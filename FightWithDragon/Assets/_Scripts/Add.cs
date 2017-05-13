using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Add : MonoBehaviour {
    public Text text;

    public static int projectile = 10;

    public static int bum = 0;
    private ScoreKeeper scoreKeeper;


    void Start() {
        scoreKeeper = GameObject.FindObjectOfType<ScoreKeeper>();
        text.text = projectile.ToString();
    }
    void add(int num) {
        projectile += num;
        text.text = projectile.ToString();

    }
    void add1(int num) {
        bum += num;
        text.text = bum.ToString();

    }


    void OnMouseDown() {
        if (ScoreKeeper.score >= 10 && gameObject.tag == "Nayzah") {
            scoreKeeper.Subtract1(10);
            ScoreKeeper.x -= 10;
            add(1);
        }

    }
    public void Subtract(int sub) {
        projectile -= sub;
        text.text = projectile.ToString();
    }



    public void Reset() {
        projectile = 10;
    }


}
