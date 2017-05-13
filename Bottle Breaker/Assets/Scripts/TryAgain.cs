using UnityEngine;
using System.Collections;

public class TryAgain : MonoBehaviour {

	public void retry(){
		Application.LoadLevel(SceneManager.currentSceneIndex);
		ScoreKeeper.score = 0;
	}
}

