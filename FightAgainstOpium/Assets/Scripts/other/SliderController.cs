using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderController : MonoBehaviour {

	// Use thisSli for initialization
	bool IsPause;
	public Slider MySlider;


	void Start () {
		IsPause = false;
	}

	public void ControlSound(){
		//if (!IsPause) {
		//	Camera.main.GetComponent<AudioListener> ().enabled = false;
		//	IsPause = true;

		//}else if(IsPause){
		//	Camera.main.GetComponent<AudioListener> ().enabled = true;
		//	IsPause = false;
	//	}

	}

	public void SliderConroller(){
		AudioListener.volume = MySlider.value;

	}
}
