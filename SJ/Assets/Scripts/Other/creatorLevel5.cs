using UnityEngine;
using System.Collections;

public class creatorLevel5 : MonoBehaviour {
	
public GameObject BigJet;
    public GameObject Spowner;


	// Update is called once per frame
	void Update () {
	if(ScoreKepper.currentScore >= 2250){
        BigJet.SetActive(true);
        Spowner.SetActive(false);
    }
	}
}
