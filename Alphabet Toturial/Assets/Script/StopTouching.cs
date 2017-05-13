using UnityEngine;
using System.Collections;

public class StopTouching : MonoBehaviour {
	[SerializeField]
	private float speed;
	void Update () {
		// for Bubbeles speeds 
		transform.Translate (new Vector3 (0, 1, 0) *speed * Time.deltaTime);
	
	}

}
