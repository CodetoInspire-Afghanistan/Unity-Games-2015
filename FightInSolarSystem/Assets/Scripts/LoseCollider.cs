using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

        public class LoseCollider : MonoBehaviour {

       // private Brick brick;
        private  Paddle paddle;
        public Ball ball;
        private SceneManager sceneManager;
        private  GameObject game;
        private  Heart heart;

    void Start(){

        heart = GameObject.FindObjectOfType<Heart>();
       // brick=GameObject.FindObjectOfType<Brick>();
        sceneManager = GameObject.FindObjectOfType<SceneManager>();

    }


    public void OnTriggerEnter2D(Collider2D other) {
        if (Heart.p>=1) {
            if (Brick.heart) {
                ball.hasStarted = false;
            }
             heart.subtract1(1);
         }
    else{
            sceneManager.LoadScene("Lose Screen");
            ScoreKeeper.x=0;

        }
    }


    void OnCollisionEnter2D(Collision2D other){

        print("Collision");

    }


}
