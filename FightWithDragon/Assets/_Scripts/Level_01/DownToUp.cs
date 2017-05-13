using System.Collections;
 using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DownToUp : MonoBehaviour {
    private bool faceRight;
    public Slider slider;
    private Add add;
    public float health = 7900f;
    public float paddingRight = 0f;

    public float speed = 2f;
    public float padding = 1f;
    public float minX;
    public float maxX;
    float projectileSpeed = 10f;
    public GameObject upProjectile;
    public GameObject rightProjectile;
    private Animator animator;
    public AudioClip laserSound;

    // Use this for initialization
    void Start () {
        faceRight = true;

        animator = GetComponent<Animator>();
        add = GameObject.FindObjectOfType<Add>();
        float distance = this.transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        minX = leftMost.x + padding;
        maxX = rightMost.x - paddingRight;

    }

    void Fire() {
        if ( gameObject.CompareTag("FiveLevel") ) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                if (Add.projectile > 0) {
                    if (faceRight) {
                        GameObject laserPlayer = Instantiate(upProjectile, transform.position + new Vector3(1, 0, 0), Quaternion.identity) as GameObject;
                        laserPlayer.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
                        add.Subtract(1);
                        AudioSource.PlayClipAtPoint(laserSound, transform.position, 1f);
                    }
                    else if (!faceRight) {
                        GameObject laserPlayer = Instantiate(upProjectile, transform.position + new Vector3(-1, 0, 0), Quaternion.identity) as GameObject;
                        laserPlayer.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed, 0);
                        add.Subtract(1);
                        AudioSource.PlayClipAtPoint(laserSound, transform.position, 1f);
                    }
                }
            }
        }

        else if (Input.GetKeyDown(KeyCode.Space)) {
            if (Add.projectile > 0) {
                //  animator.SetBool("SecondLevel", true)
                GameObject laserPlayer = Instantiate(upProjectile, transform.position + new Vector3(0, 1, 0), Quaternion.identity) as GameObject;
                laserPlayer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
                add.Subtract(1);

                AudioSource.PlayClipAtPoint(laserSound, transform.position, 1f);
            }
        }


    }


    void OnTriggerEnter2D(Collider2D other) {
        Projectile missile = other.gameObject.GetComponent<Projectile>();
        if (missile) {
            health -= missile.getDamage();
            slider.value -= 10;
            missile.Hit();
            if (health <= 0) {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                SceneManager sceneManager = GameObject.FindObjectOfType<SceneManager>();
                sceneManager.LoadScene("LoseScreen");
                Destroy(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update () {


        Fire();

        if (Input.GetKey(KeyCode.LeftArrow)) {
            faceRight = false;
            animator.SetBool("IsLeft", true);
            this.transform.localScale = new Vector3(-0.5866919f, 0.5866919f, 1);
            transform.position += Vector3.left * speed * Time.deltaTime;

        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            if(gameObject.CompareTag("FiveLevel")){
                animator.SetBool("IsLeft", true);

            }
            else{
                animator.SetBool("IsLeft", false);

            }
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            faceRight = true;
            animator.SetBool("IsRight", true);
            this.transform.localScale = new Vector3(0.5866919f, 0.5866919f, 1);

            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            if (gameObject.CompareTag("FiveLevel")) {
                animator.SetBool("IsRight", true);

            }
            else {
                animator.SetBool("IsRight", false);
            }
        }

        //        else if (Input.GetKey(KeyCode.F)){
        //            print("abs");
        //         add.Subtract(1);
        //        }

        float newX = Mathf.Clamp(transform.position.x, minX, maxX)  ;
        this.transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
