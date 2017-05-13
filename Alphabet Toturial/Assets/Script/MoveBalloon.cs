using UnityEngine;
using System.Collections;

public class MoveBalloon: MonoBehaviour {
		public float width = 13f;
		public float height = 5f;
		bool moveRight = true;
		public float speed = 2f;
		public float minX;
		public float maxX;

		// Use this for initialization
		void Start () {
			float distance = this.transform.position.z - Camera.main.transform.position.z;
			Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));

			Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
			minX = leftMost.x-1;
		    maxX = rightMost.x+1;


		}

	void ChangeDirection(){
		Vector3 theScale = transform.localScale;
		theScale.x*= -1;
	    transform.localScale = theScale;

	}


		void Update (){
		
	float rightEdgeOfFormation = transform.position.x + 0.5f * width;
		float leftEdgeOfFormation = transform.position.x - 0.5f * width;

             if (moveRight) {
			transform.position += Vector3.right * Time.deltaTime * speed ;
			Vector3 theScale = transform.localScale;
			theScale.x= 1;
			transform.localScale = theScale;

		} else {
			
			transform.position += Vector3.left * Time.deltaTime * speed;
			Vector3 theScale = transform.localScale;
			theScale.x= -1;
			transform.localScale = theScale;
		}

		if (rightEdgeOfFormation > maxX) {
			moveRight = false;

		} else if (minX > leftEdgeOfFormation) {
			moveRight = true;
		}
	}
}