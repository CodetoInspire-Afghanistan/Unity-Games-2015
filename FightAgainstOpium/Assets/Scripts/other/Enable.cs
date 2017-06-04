using UnityEngine;
using System.Collections;

public class Enable : MonoBehaviour {

	public  GameObject [] ob;

	void Update(){
		
			StartCoroutine(Talk());
		}


	IEnumerator Talk(){
		for(int i=0;i<ob.Length;i++){
			ob[i].gameObject.SetActive(true);
			//print("asaaa");
			yield return new WaitForSeconds(0.5f);

		}
	}
}
