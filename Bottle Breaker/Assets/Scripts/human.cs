using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class human : MonoBehaviour {

	public float speed = 2f;
	public GameObject projectile;
	public float projectileSpeed = 5f;
	public float fireRate = 0.02f;
	public float maxSton = 50f;
	public float currentStone = 0;
	public Text text;

	// Use this for initialization
	void Start () {
		currentStone = maxSton;

	}
	void Fire() {
		GameObject laserplayer = Instantiate(projectile, transform.position + new Vector3(-0.5f, 1f, 0), Quaternion.identity)as GameObject;
		laserplayer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {

			if (currentStone > 0) {
				Fire();
				currentStone -= 1;

				text.text = currentStone.ToString();
			}




		}
	}
}


