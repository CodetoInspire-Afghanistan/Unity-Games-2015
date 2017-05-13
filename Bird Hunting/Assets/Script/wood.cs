using UnityEngine;
using System.Collections;

public class wood : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other){
        Destroy (this.gameObject);
		Destroy (other.gameObject);
    }
}
