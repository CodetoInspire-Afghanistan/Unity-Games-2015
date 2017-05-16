using UnityEngine;
using System.Collections;

public class MovementObstacle : MonoBehaviour {

	bool moveTop = true;

	public float speed;

	public Vector3 V3Top;
	public Vector3 V3Down;

	float maxY;
	float minY;


	// Use this for initialization
	void Start () {

		Vector3 topMost = V3Top;
		Vector3 downMost = V3Down;

		minY = topMost.y;
		maxY = downMost.y;
	}

	//set up and down directions for moveable obstacles
	// Update is called once per frame
	void Update () {
		if (moveTop) {
			transform.position += Vector3.up * Time.deltaTime * speed;
		} else {
			transform.position += Vector3.down * Time.deltaTime * speed;
		}
		float topEdgeOfFormation = transform.position.y;
		float downEdgeOfFormation = transform.position.y;
		if (topEdgeOfFormation > minY) {
			moveTop = false;
		} else if (maxY > downEdgeOfFormation) {
			moveTop = true;

		}
	}
}
