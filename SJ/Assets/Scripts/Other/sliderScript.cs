using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class sliderScript : MonoBehaviour {


	private Slider slil;
	private PlayerController player;
	private BigJetSpowner bigJetSpowner;


	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<PlayerController> ();
		bigJetSpowner = GameObject.FindObjectOfType<BigJetSpowner> ();
		slil = GetComponent<Slider> ();
	}


	// Update is called once per frame
	void Update () {
		slil.value -= 0.1f * Time.deltaTime;
		if(slil.value!=0 && BigJetSpowner.bigJetIsDead==true){
			
			player.health = 100;
			Destroy (gameObject);

		}
	}
}
