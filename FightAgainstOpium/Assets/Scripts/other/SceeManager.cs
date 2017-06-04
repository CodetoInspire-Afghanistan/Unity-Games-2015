using UnityEngine;
using System.Collections;

public class SceeManager : MonoBehaviour {
 	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void ScenLoader(string name){
		UnityEngine.SceneManagement.SceneManager.LoadScene (name);
	}

	public void Quit(){
		Application.Quit ();
	}
}
