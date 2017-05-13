using UnityEngine;
using System.Collections;

public class Umbrella : MonoBehaviour {
public AudioClip Coin;
    void Start(){


    }
	void Update() {

		MoveWithMouse();

	}


		void MoveWithMouse(){
			Vector3 umbrellaPosition = transform.position;
			float mousePosition = Input.mousePosition.x / Screen.width * 16;
			umbrellaPosition.x = Mathf.Clamp(mousePosition, 2.19f, 13.8f);
			this.transform.position = umbrellaPosition;
		}

	void OnCollisionEnter2D(Collision2D other)
	{
        Destroy(other.gameObject);
        AudioSource.PlayClipAtPoint(Coin,transform.position);


	}
}