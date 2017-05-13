using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {
    public GameObject fire;
    public Transform child;
    public float projectileSpeed = 4f;

    public AudioClip fire1;

    void fireProjectile() {
        GameObject enemyFire = Instantiate(fire, transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(fire1, transform.position, 1f);

        enemyFire.transform.parent = child;
        enemyFire.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }


    void Update() {
        if (Random.value < Time.deltaTime ) {
            fireProjectile();
        }
    }
}
