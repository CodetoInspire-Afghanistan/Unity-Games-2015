using Mono.Xml.XPath.yyParser;
using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Director;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {


    public Text text;
    public static int score = 0;

    void Start () {
//

    }void Update(){

    }




        public void IncreaseScore(){
         score+=1;
         //print(score);
         text.text=score.ToString();
}
        public void DecreaseScore(){
            score-=1;

            text.text=score.ToString();
}

}