using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Arabic : MonoBehaviour {
public  Text t;
	// Use this for initialization
	void Start () {
	t.text = ArabicSupport.ArabicFixer.Fix(t.text );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
