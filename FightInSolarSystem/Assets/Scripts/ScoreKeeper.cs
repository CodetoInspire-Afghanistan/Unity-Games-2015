using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
//public int heart1=0;
    public Text text;
   // public Text heart;
    public static int score = 0;
    public static int x = 0;

    // Use this for initialization
    void Start () {
        text.text = score.ToString ();

    }

     void Update () {

    }
    public void add(int amount){
        score += amount;
        text.text = score.ToString ();
    }
    public void subtract(int amount){
        score -= amount;
        text.text = score.ToString ();
    }

    public static void Reset(){
          score = 0;

    }
}
