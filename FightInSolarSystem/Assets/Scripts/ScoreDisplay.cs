using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
    public  Text myText;
     void Start () {
         myText.text = ScoreKeeper.score.ToString();
        ScoreKeeper.Reset();

    }

}
