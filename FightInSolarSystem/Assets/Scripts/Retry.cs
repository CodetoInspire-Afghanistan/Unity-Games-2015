using UnityEngine;
using System.Collections;

public class Retry : MonoBehaviour {
	public void retry() {
		UnityEngine.SceneManagement.SceneManager.LoadScene (SceneManager.currentSceneIndex);

	}
}
