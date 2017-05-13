using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    public AudioClip Coin_Sound;
    Quaternion rotation;


    void Start() {

        rotation = transform.localRotation;
        InvokeRepeating("Rotate", 000.1f, 0.01f);
    }
    void Rotate() {
        rotation.y += 0.05f;
        print(rotation);
        if (rotation.y >= 3.2f) {
            rotation.y = 0;
        }
        this.transform.rotation = rotation;
    }

    void OnCollisionEnter2D(Collision2D other) {


        AudioSource.PlayClipAtPoint(Coin_Sound, transform.position);
        Destroy(this.gameObject);

        }


    }



