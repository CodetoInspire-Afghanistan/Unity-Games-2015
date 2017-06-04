using UnityEngine;
using System.Collections;

public class SlideShow : MonoBehaviour {

	public GameObject[] images;
	int i=1;
	float timme = 2f;

	void Start(){
		InvokeRepeating ("next", timme,2f);
	}


	public void next(){
		images [i].gameObject.SetActive (true);
		timme--;
		if (timme < 0) {
			i++;
		}
		if(i==images.Length){
			i = 4;
		}
	}





//	public void back(){
//		images[i].gameObject.SetActive(false);
//
//		i--;
//		if(i<=1){
//			i = 1;
//		}
//
//
//	}


}