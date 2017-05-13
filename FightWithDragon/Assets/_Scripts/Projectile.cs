using UnityEngine;
using System.Collections;
public class Projectile : MonoBehaviour {
    public float damage = 10f;
    public void Hit() {
        Destroy(gameObject);
    }
    public float getDamage() {
        return  damage;
    }
}
