using UnityEngine;
using System.Collections;


public class CollisionTrigger : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D platformCollider;

    [SerializeField]
    private BoxCollider2D platformTrigger;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Enemy") 
        {
            Physics2D.IgnoreCollision(platformCollider, other, true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(platformCollider, other , false);
        }
    }
	
}
