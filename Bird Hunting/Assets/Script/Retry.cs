using UnityEngine;
using System.Collections;

public class Retry : MonoBehaviour {

	public void retry(){
		Application.LoadLevel(SceneManage.currentSceneIndex);
		ScoreKeeper.score = 0;
	}





}
