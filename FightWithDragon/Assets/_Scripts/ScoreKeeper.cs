using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
    public Text text;
    public static int score = 0;
    public static int x = 0;
    // Use this for initialization
    void Start () {
        text.text = score.ToString();
    }

    // Update is called once per frame
    public void add(int pint) {
        score += pint;
        text.text = score.ToString();
    }
    public static void Reset() {
        score = 0;
    }

    public void Subtract1(int pint) {
        score -= pint;
        text.text = score.ToString();
    }
}
