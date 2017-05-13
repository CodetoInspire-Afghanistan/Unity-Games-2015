using System.Collections;
using UnityEngine;


public class Ball : MonoBehaviour {


    Vector3 ballToPaddleDistance;

    public bool hasStarted = false;

    private Paddle paddle;

    // Use this for initialization
    void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        ballToPaddleDistance = this.transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update () {
		if (!hasStarted) {
			this.transform.position = ballToPaddleDistance + paddle.transform.position;
		
			if (Input.GetMouseButtonDown (0)) {
				hasStarted = true;
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 10f);

            
			}
		}

    }


    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("abc")) {
            Destroy(other.gameObject);
            Brick.breakableCount++;
            this.transform.localScale += new Vector3(0.5f, 0.5f, 0);
        }
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        Brick brick = other.gameObject.GetComponent<Brick>();

        if (brick == null) {
            if (hasStarted) {
                this.GetComponent<AudioSource>().Play();
                GetComponent<Rigidbody2D>().velocity += tweak;
            }
        }
    }
}
