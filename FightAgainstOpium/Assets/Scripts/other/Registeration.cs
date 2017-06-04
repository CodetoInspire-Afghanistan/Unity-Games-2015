using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Registeration : MonoBehaviour {

	public static string name;
	public InputField NameField;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Register(){

			name = NameField.text.ToString ();
			print (name);


	}
}
