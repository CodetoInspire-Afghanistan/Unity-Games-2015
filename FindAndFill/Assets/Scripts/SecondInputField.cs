using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SecondInputField : MonoBehaviour {

		[SerializeField]
            private  Text textFirstPlayer;
    [SerializeField]
    private  Text textsecondPlayer;

	void Start () {

	}
    void Update () {
        textFirstPlayer.text=MyTextField.firstPlayer+"";
        textsecondPlayer.text=MyTextField.secondPlayer+"";
    }





}
