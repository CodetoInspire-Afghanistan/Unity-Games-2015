using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AutoTyping : MonoBehaviour {
    public Text text;
    public string myString = "";
    public float delayLatter;
    // Use this for initialization
    void Start () {
        StartCoroutine("TypeText");

    }
    IEnumerator TypeText() {
        foreach (char latter in myString.ToCharArray()) {
            text.text += latter;
            yield return  0;
            yield  return new WaitForSeconds(delayLatter);
        }
    }

}
