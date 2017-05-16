using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderController : MonoBehaviour {


	public float timeTillPlant = 0f;
	public float timeDelayPlant = 20f;
	public Slider sli;

	
	// Update is called once per frame
	void Update () {
		timeTillPlant -= Time.deltaTime;
		sli.value = timeTillPlant / timeDelayPlant;
		if (timeTillPlant <= 0) {

		}
	}
}
