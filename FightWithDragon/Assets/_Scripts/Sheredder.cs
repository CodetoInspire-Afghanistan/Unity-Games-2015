using UnityEngine;
using System.Collections;

public class Sheredder : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        Destroy(other.gameObject);
    }
}
