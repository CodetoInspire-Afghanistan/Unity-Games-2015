using System.Collections;
using UnityEngine;
using UnityEngine.UI;




public class SceneManager : MonoBehaviour {
	public void loadScene(string n){
        Application.LoadLevel(n);
    }




    public void QuitRequest ()
    {
        Application.Quit();
    }

}
