using UnityEngine;
using System.Collections;

public class DiscriptionPaddles : MonoBehaviour {
    public GameObject enemyPrefab;
    public  float height =10f;
    bool moveUp=true;
    public float speed=5f;
    //float miny;
    float maxy;

     void Start () {
        float distance=this.transform.position.z-Camera.main.transform.position.z;
       // Vector3 leftMoat=Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
        Vector3 rightMost=Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
        //miny=leftMoat.x;
        maxy=rightMost.x;
        foreach (Transform child in transform) {
            GameObject enemy=Instantiate(enemyPrefab, child.transform.position,Quaternion.identity)as GameObject;
            enemy.transform.parent=child;

        }
     }


     void Update () {
        if (moveUp){
            transform.position+=Vector3.up*Time.deltaTime*speed;
        }

        float rightEdgeOfFormation=transform.position.y+0.5f*height;
         if (rightEdgeOfFormation>maxy){
            moveUp=false;
        }

    }

}
