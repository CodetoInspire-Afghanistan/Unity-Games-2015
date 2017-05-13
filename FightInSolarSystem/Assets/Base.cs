using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {

        private GameObject a;
        private GameObject b;
        private GameObject c;
        private GameObject d;
        private GameObject e;
        private GameObject f;
        private GameObject g;
        private GameObject h;
       // private GameObject i;

       private  ScoreKeeper scoreKeeper;
//       private  Heart heart;
       //private  SceneManager sceneManager;
        void Start(){
            scoreKeeper=GameObject.FindObjectOfType<ScoreKeeper>();
           // sceneManager=GameObject.FindObjectOfType<SceneManager>();
            //heart=GameObject.FindObjectOfType<Heart>();
            a=GameObject.Find("a1") as GameObject;
            b=GameObject.Find("a2") as GameObject;
            c=GameObject.Find("a3") as GameObject;
            d=GameObject.Find("a4") as GameObject;
            e=GameObject.Find("a5") as GameObject;
            f=GameObject.Find("a6") as GameObject;
            g=GameObject.Find("a7") as GameObject;
            h=GameObject.Find("a8") as GameObject;
            //i=GameObject.Find("a9") as GameObject;
         }
       void OnCollisionEnter2D(){
          Destroy(gameObject);
            if(a.name=="a1" && b.name=="a2"&&c.name=="a3"
            &&d.name=="a4" && e.name=="a5"&& f.name=="a6" && g.name=="a7" && h.name=="a8"){
                Destroy(a.gameObject);
                scoreKeeper.add(1);
                ScoreKeeper.x++;
                Destroy(b.gameObject);
                scoreKeeper.add(1);
                ScoreKeeper.x++;
                Destroy(c.gameObject);
                scoreKeeper.add(1);
                ScoreKeeper.x++;
                Destroy(d.gameObject);
                scoreKeeper.add(1);
                ScoreKeeper.x++;
                Destroy(e.gameObject);
                scoreKeeper.add(1);
                ScoreKeeper.x++;
                Destroy(f.gameObject);
                scoreKeeper.add(1);
                ScoreKeeper.x++;
                Destroy(g.gameObject);
                scoreKeeper.add(1);
                ScoreKeeper.x++;
                Destroy(h.gameObject);
                //Brick.breakableCount++;
              //  Destroy(i.gameObject);
                //Brick.breakableCount++;
               // scoreKeeper.add(9);
               // ScoreKeeper.x+=5;
               // sceneManager.brickDestroyed();
                }


     }
    }



