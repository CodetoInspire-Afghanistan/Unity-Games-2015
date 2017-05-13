using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class P_Display : MonoBehaviour {

    public  Text myText;
    void Start () {
        myText.text = Heart.p.ToString();
        Heart.reset();

    }
}
