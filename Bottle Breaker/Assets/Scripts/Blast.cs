using UnityEngine;
using System.Collections;

public class Blast : MonoBehaviour {

    public GameObject SmokePuff;

    public AudioClip Bomb;
        private GameObject bottle1;
        private GameObject bottle2;
        private GameObject bottle3;
        private GameObject bottle4;
        private GameObject bottle5;
        private GameObject bottle6;


    void Start(){
        bottle1=GameObject.Find("around1") as GameObject;
        bottle2=GameObject.Find("around2") as GameObject;
        bottle3=GameObject.Find("around3") as GameObject;
        bottle4=GameObject.Find("around4") as GameObject;
        bottle5=GameObject.Find("around5") as GameObject;
        bottle6=GameObject.Find("around6") as GameObject;

        //  bottle=GameObject.Find("around") as GameObject;
    }
	void OnCollisionEnter2D(Collision2D other){
        AudioSource.PlayClipAtPoint(Bomb, transform.position);

        Destroy(gameObject);
        Instantiate(SmokePuff,transform.position,Quaternion.identity);


        if(bottle1.name=="around1" && bottle2.name=="around2"&&bottle3.name=="around3"&&bottle4.name=="around4"&&bottle5.name=="around5"&&bottle6.name=="around6"){
            Destroy(bottle1.gameObject);
            Destroy(bottle2.gameObject);
            Destroy(bottle3.gameObject);
            Destroy(bottle4.gameObject);
            Destroy(bottle5.gameObject);
            Destroy(bottle6.gameObject);

        }

    }
}
