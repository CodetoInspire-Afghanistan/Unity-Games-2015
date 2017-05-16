using UnityEngine;
using System.Collections;

public class Help : MonoBehaviour {


        bool moveRight = true;
        public float speed = 15f;
        public float width = 10f;
        public GameObject projectile;
        float maxX;
        float minX;

        // Use this for initialization
        void Start () {

            float distence = this.transform.position.z - Camera.main.transform.position.z;
            Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distence));
            Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distence));
            minX = leftMost.x;
            maxX = rightMost.x;

            InvokeRepeating("Firee", 0.00001f, 0.2f);

        }

        // Update is called once per frame
        void Update () {

            if (moveRight) {
                transform.position += Vector3.right * Time.deltaTime * speed;
            } else {
                transform.position += Vector3.left * Time.deltaTime * speed;
            }

            float rightEdgeOfFormation = transform.position.x + 1.2f;
            float leftEdgeOfFormation = transform.position.x - 1.2f;

            if (rightEdgeOfFormation > maxX) {
                moveRight = false;
            } else if (minX > leftEdgeOfFormation) {
                moveRight = true;

            }

        }

	// for shooting layser
        void Firee(){
            GameObject Layser = Instantiate(projectile, this.transform.position , Quaternion.identity) as GameObject;
            Layser.GetComponent<Rigidbody2D> ().velocity = new Vector2(0f,10f);
        }

	// for checking the trigger of gameobjects with helper jet
        void OnTriggerEntrer2D(Collider2D other){

            Destroy (other.gameObject);
        }

    }
