using UnityEngine;
using System.Collections;

public class Instantiate_A : MonoBehaviour {

	public  GameObject a;
    private  ScoreKeeper scoreKeeper;

    void OnCollisionEnter2D() {
        Instantiate(a, transform.position + new Vector3(6, 2, 0), Quaternion.identity);
        Instantiate(a, transform.position + new Vector3(5, 2, 0), Quaternion.identity);
        Instantiate(a, transform.position + new Vector3(4, 2, 0), Quaternion.identity);
        Instantiate(a, transform.position + new Vector3(3, 2, 0), Quaternion.identity);
        Instantiate(a, transform.position + new Vector3(2, 2, 0), Quaternion.identity);
        Instantiate(a, transform.position + new Vector3(1, 2, 0), Quaternion.identity);
    }
}
