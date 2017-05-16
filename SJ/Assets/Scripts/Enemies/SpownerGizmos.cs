using UnityEngine;
using System.Collections;

public class SpownerGizmos : MonoBehaviour {

	// Use this for initialization
	public float spawnerRadius= 1f;
	void OnDrawGizmos() {
		Gizmos.color= Color.red;
		Gizmos.DrawWireSphere (transform.position, spawnerRadius);

	}

	void OnDrawGizmosSelected() {
		Gizmos.color= Color.green;
		Gizmos.DrawWireSphere (transform.position, spawnerRadius);

	}

}
