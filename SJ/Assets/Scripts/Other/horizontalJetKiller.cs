using UnityEngine;
using System.Collections;

public class horizontalJetKiller : MonoBehaviour {

	//for checking the trigger of horizontal jet with playerjet
    void OnTriggerEnter2D(Collider2D other){
	if (other.CompareTag("HrJet"))
		{
	Destroy(other.gameObject);

	}
    }
}
