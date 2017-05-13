using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour {
    public static float  p = 0;
    public Text text;
    public AudioClip a;
    // private  Brick brick;

    void Start () {
        // brick=GameObject.FindObjectOfType<Brick>();
        text.text = p.ToString();
    }

    void Update () {
        if (ScoreKeeper.x >= 5) {
            Brick.heart = true;
            AudioSource.PlayClipAtPoint(a, this.transform.position, 1f);
            p++;
            text.text = p.ToString();
            ScoreKeeper.x = 0;
        }

    }


    public void subtract1(int amount) {
        p -= amount;
        text.text = p.ToString();
    }
    public static void reset() {
        p = 0;
    }
}
