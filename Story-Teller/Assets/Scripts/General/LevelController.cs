using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour {
	[SerializeField]
	private GameObject MyPanel;
	// Use this for initialization


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadNewScene(string sceneName){

		SceneManager.LoadScene (sceneName);
	}
	public void Quit(){
		Application.Quit ();	

	}
	public void ShowSearch(){
		MyPanel.SetActive (true);
	}
	public void Twetter(){

		Application.OpenURL ("https://twitter.com/Hasina_Haidari1");
	}
	public void GitHub(){
		Application.OpenURL ("https://github.com/HasinaHaidari");
	}


}
