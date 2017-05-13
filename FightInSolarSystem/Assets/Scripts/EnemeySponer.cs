using UnityEngine;
using System.Collections;

public class EnemeySponer : MonoBehaviour {
public GameObject enemyPrefab;
    public  float width =15f;
    public  float height =10f;
    bool moveRight=true;
    public float speed=5f;
    float minX;
    float maxX;
 	void Start () {
        float distance=this.transform.position.z-Camera.main.transform.position.z;
        Vector3 leftMoat=Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
        Vector3 rightMost=Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
        minX=leftMoat.x;
        maxX=rightMost.x;

        foreach (Transform child in transform) {
            GameObject enemy=Instantiate(enemyPrefab, child.transform.position,Quaternion.identity)as GameObject;
            enemy.transform.parent=child;
        }
    }


	void Update () {
	if (moveRight){
        transform.position+=Vector3.right*Time.deltaTime*speed;
    }
    else{
        transform.position+=Vector3.left*Time.deltaTime*speed;

    }
        float rightEdgeOfFormation=transform.position.x+0.5f*width;
        float leftEdgeOfFormation=transform.position.x-0.5f*width;
        if (rightEdgeOfFormation>maxX){
            moveRight=false;
        }
        else if (leftEdgeOfFormation<minX){
            moveRight=true;
        }
	}

}
