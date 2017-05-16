using UnityEngine;
using System.Collections;

public class ObstacleMovement : MonoBehaviour {

	bool moveRight = true;

	public float speed;

	public Vector3 V3Left;
	public Vector3 V3Right;

	float maxX;
	float minX;


	// Use this for initialization
	void Start () {
		Vector3 leftMost = V3Left;
		Vector3 rightMost = V3Right;
		minX = leftMost.x;
		maxX = rightMost.x;
	}


	//set right and left directions for moveable obstacles
	// Update is called once per frame
	void Update () {
		if (moveRight) {
			transform.position += Vector3.right * Time.deltaTime * speed;
		} else {
			transform.position += Vector3.left * Time.deltaTime * speed;
		}
		float rightEdgeOfFormation = transform.position.x;
		float leftEdgeOfFormation = transform.position.x;
		if (rightEdgeOfFormation > maxX) {
			moveRight = false;
		} else if (minX > leftEdgeOfFormation) {
			moveRight = true;

		}
	}
		
}
