using UnityEngine;
using System.Collections;

public class Larger : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Breakable")){
            Destroy(other.gameObject);
            this.transform.localScale+=new Vector3(1f,1f,0);
	    }
    }
}
