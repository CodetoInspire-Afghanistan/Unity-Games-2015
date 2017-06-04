using UnityEngine;
using System.Collections;

public class SwordCollider : MonoBehaviour {

    [SerializeField]
    private string targetTag;

    private Collider2D myCollider;

    void Start()
    {
        myCollider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == targetTag)
        {
            myCollider.enabled = false;
        }
    }
}
