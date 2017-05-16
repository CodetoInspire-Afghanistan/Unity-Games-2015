using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SkipLevel : MonoBehaviour {

	// Use this for initialization
	public Button S;
	public Text Skip;
	public static int skipCounter=2;

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Skip.text= skipCounter.ToString ();
		if(skipCounter <= 0){
			S.gameObject.SetActive (false);
		}
	}

	public void SkipThisLevel(){
		
		if (skipCounter > 0 ) {
			skipCounter -= 1;
			if (ScoreKeeper.scoreCalculator > 0) {
				ScoreKeeper.scoreCalculator -= 1;
			}
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
		Skip.text = skipCounter.ToString ();
		}

		
	}
}
