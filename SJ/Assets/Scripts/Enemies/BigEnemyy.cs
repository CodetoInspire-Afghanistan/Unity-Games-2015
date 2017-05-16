using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BigEnemyy : MonoBehaviour {


    bool moveRight = true;
    public float speed = 10f;
    public float width = 10f;
    public GameObject projectile;
    public float health = 300f;
	public float Padding = 0.8f;
	public AudioClip Helicoptersound;

    float maxX;
    float minX;

    // Use this for initialization
    void Start () {
		AudioSource.PlayClipAtPoint (Helicoptersound,transform.position);
        float distence = this.transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distence));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distence));
		minX = leftMost.x+Padding;
		maxX = rightMost.x-Padding;

        InvokeRepeating ("Fire",0.01f, 1f);

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
           Face();

        } else if (minX > leftEdgeOfFormation) {
            moveRight = true;
         Face();

        }


    }

    void Fire(){
        GameObject Layser = Instantiate(projectile, this.transform.position+ new Vector3(0,-1,0) , Quaternion.identity) as GameObject;
        Layser.GetComponent<Rigidbody2D> ().velocity = new Vector2(0f,-10f);
    }


    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("PlayerBullet")) {
            DecreaseDamage(10);
            if (health <= 0) {
              //  print(health);
                ScoreKepper.currentScore += 750;
                Destroy(gameObject);
               // Application.LoadLevel("WinScreen");

            }
        }
        //Destroy(other.gameObject);
    }


    void Face(){
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    public void DecreaseDamage(int amount){
        health -= amount;
    }
}
