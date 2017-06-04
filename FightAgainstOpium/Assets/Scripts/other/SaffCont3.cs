using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SaffCont3 : MonoBehaviour {

		// Use this for initialization
		public Button Safferon;
		public GameObject Saff;
		public Sprite OK;

		void Start () {
			Saff.SetActive (false);

		}

		public void GrowSafferon(){
			Saff.SetActive (true);
			Safferon.gameObject.GetComponent<Image> ().sprite = OK;
		}
	}
