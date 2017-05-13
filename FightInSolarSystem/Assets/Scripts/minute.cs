
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class minute : MonoBehaviour {


        public int start=0;
        public int end=50;
        public int sceneNumber;
        public Text text;
        bool x = true;
        private Heart heart;


        // Use this for initialization
        void Start () {
            heart=GameObject.FindObjectOfType<Heart>();
            InvokeRepeating("decreaseTime",1f,1f);



        }

        // Update is called once per frame
        void Update (){
            if (start==end && x){
                Brick.breakableCount = 0;
                x = false;
                NextLevel();

            }
            text.text=start.ToString();
        }


        void decreaseTime(){
            start-=1;
            print(start);
        }

        void NextLevel(){

            if (Heart.p>=0 && !x){
                heart.subtract1(1);
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNumber);

            }

             if(Heart.p==-1){
                UnityEngine.SceneManagement.SceneManager.LoadScene("Lose Screen");


            }

        }
    }


