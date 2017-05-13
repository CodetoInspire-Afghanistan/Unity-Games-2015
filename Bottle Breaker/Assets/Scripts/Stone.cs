using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {

    Vector3 stoneToPaddleDistance;
    private Paddle paddle;
    bool hasStarted = false;

    void Start () {

        paddle = GameObject.FindObjectOfType<Paddle>();
        stoneToPaddleDistance = this.transform.position - paddle.transform.position;

    }


    void Update () {
        if (!hasStarted) {
            this.transform.position = stoneToPaddleDistance + paddle.transform.position;
            if (Input.GetMouseButtonDown(0)) {

                hasStarted = true;

                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f);
            }

        }
    }
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("GoodCoin")) {
                this.transform.localScale += new Vector3(0.5f, 0.3f, 0);
               paddle.transform.localScale += new Vector3(0.2f, 0.2f, 0);


           } else if (col.gameObject.CompareTag("BadCoin")) {
            this.transform.localScale -= new Vector3(0.3f, 0.3f, 0);
            paddle.transform.localScale -= new Vector3(0.2f, 0.2f, 0);

        }
           Vector2 tweak = new Vector2(Random.Range(0f, -0.2f), Random.Range(0f, -0.2f));
            Bottles bottles = col.gameObject.GetComponent<Bottles>();
            if (bottles == null) {
                if (hasStarted) {

           GetComponent<Rigidbody2D>().velocity += tweak;
                }
            }
        }
    }
