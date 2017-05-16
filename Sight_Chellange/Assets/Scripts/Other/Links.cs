using UnityEngine;
using System.Collections;

public class Links : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void Facebook(){
		Application.OpenURL ("https://www.facebook.com/profile.php?id=100006025068444&ref=brrs");
	}
	public void Twetter(){
		Application.OpenURL ("https://twitter.com/Hasina_Haidari1");
	}
	public void GitHub(){
		Application.OpenURL ("https://github.com/HasinaHaidari");
	}
}
