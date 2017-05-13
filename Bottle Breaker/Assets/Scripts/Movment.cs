

    using UnityEngine;
    using System.Collections;

    public class Movment : MonoBehaviour {

        public GameObject enemeyPrefab;
       public float width=10f;
       public float heigth=6f;
        bool moveRight=true;
        public float speed=5f;
        float minX;
        float maxX;
        // Use this for initialization
        void Start () {
            float Distance=this.transform.position.z-Camera.main.transform.position.z;
            Vector3 leftmost=Camera.main.ViewportToWorldPoint(new Vector3(0,0,Distance));
            Vector3 rightmost=Camera.main.ViewportToWorldPoint(new Vector3(1,0,Distance));
            minX = leftmost.x;
            maxX = rightmost.x;
            foreach (Transform child in transform) {
                GameObject enemy = Instantiate (enemeyPrefab, child.transform.position, Quaternion.identity) as GameObject;
                enemy.transform.parent = child;
            }
        }
        void OnDrawGizmos(){
            Gizmos.DrawWireCube (transform.position,new Vector3 (width, heigth));
        }
        // Update is called once per frame
        void Update () {

            if (moveRight) {
                transform.position += Vector3.right * Time.deltaTime * speed;
            }
            else{

                transform.position += Vector3.left * Time.deltaTime * speed;

            }
            float RighEdgeOfFormation = transform.position.x + 0.5f * width;
            float leftedgeofFormation=transform.position.x-0.5f*width;
            if (RighEdgeOfFormation > maxX) {
                moveRight = false;
            }
            else if(leftedgeofFormation<minX){
                moveRight = true;



            }

        }
    }


