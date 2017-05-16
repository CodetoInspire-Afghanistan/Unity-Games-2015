using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

	// Use this for initialization

	public Text text;
	public bool paused;
	public GameObject myPanel;

	// Use this for initialization
	void Start () {
		paused = false;
	}

	//for pause button of game
	public void pause(){
		
		paused = !paused;
		if (paused) {

			Time.timeScale = 0;
		} else if (!paused) {

			Time.timeScale = 1;
		}

	}


	// Update is called once per frame
    void Update(){
        if(Time.timeScale==0){
            text.text = "Play";

        }
        else{
            text.text = "Pause";

        }
    }


	void OnMouseDown(){
		
		if (gameObject.CompareTag ("Close"))
			myPanel.SetActive (false);	
	 else {

		myPanel.SetActive (true);

	}

}

	//for closing pause panel of game
	public void ClosePanel(){
		myPanel.SetActive (false);

	}
}
