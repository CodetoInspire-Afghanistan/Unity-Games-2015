using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior1 : MonoBehaviour {
     public float health = 150f;
    public float projectileSpeed = 10f;
    public GameObject EnemyLaser;
    public float minimumFireTime = 2f;
    public float maximumFireTime = 4f;
    public float fireCofficient = 0.5f;
    private ScoreKeeper scoreKeeper;
    public int scoreValue = 150;
    private SceneManager sceneManager;
    public AudioClip fire;
    GameObject a,b,c,d;
    public AudioClip enemyDestroyedsound;
    void Start() {


        sceneManager = GameObject.FindObjectOfType<SceneManager>().GetComponent<SceneManager>();
        scoreKeeper = GameObject.FindObjectOfType<ScoreKeeper>().GetComponent<ScoreKeeper>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        Projectile missile = other.gameObject.GetComponent<Projectile>();
        if (missile) {
            health -= missile.getDamage();

            missile.Hit();
            if (health <= 0) {
                AudioSource.PlayClipAtPoint(enemyDestroyedsound, transform.position, 1f);
                Destroy(gameObject);

                scoreKeeper.add(scoreValue);
                ScoreKeeper.x += scoreValue;
            }
        }
        else if ( other.gameObject.CompareTag("FiveLevel")) {

            sceneManager.LoadScene("LoseScreen");
        }
    }
    void Update() {

        if (this.CompareTag("Fire")) {
            if (Random.value < Time.deltaTime * fireCofficient) {
                Fire();

            }
        }
    }



    void Fire() {
        GameObject EnemyLaserPrefab = Instantiate(EnemyLaser, transform.position + new Vector3(0, -1, 0), Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(fire, transform.position, 0.5f);

        EnemyLaserPrefab.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }

}
