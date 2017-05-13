using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {
    void OnDrawGizmos() {
        Gizmos.DrawWireSphere(this.transform.position, 1);
    }
}
