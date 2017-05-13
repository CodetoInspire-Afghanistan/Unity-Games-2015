using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseNumber : MonoBehaviour {
    public Text myText;

    void Start () {
        myText = this.GetComponent<Text>();
        myText.text = Add.projectile.ToString();


    }


}