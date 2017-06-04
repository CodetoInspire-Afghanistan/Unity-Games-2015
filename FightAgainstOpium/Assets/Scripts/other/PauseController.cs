using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseController : MonoBehaviour {

	public Button PauseLogo;
	public Sprite PlaySprite;
	public Sprite PauseSprite;
	bool isPause;
	
	// Update is called once per frame
	void Update () {
	
	}
	void Start(){

		isPause = false;
	}
	public void Pause(){

		isPause = !isPause;
		if (isPause) {
			Time.timeScale = 0;
			PauseLogo.GetComponent<Image> ().sprite = PlaySprite;

		} else if(!isPause) {
			Time.timeScale = 1;
			PauseLogo.GetComponent<Image> ().sprite = PauseSprite;

		}
	}

}
