using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyTextField : MonoBehaviour {
    // Use this for initialization
    [SerializeField]
    private InputField player1;
    [SerializeField]
    private InputField player2;
 
    //public  Text text;

     public static string firstPlayer;
    public static string secondPlayer;

    void Start () {
       

    }

    // Update is called once per frame
    void Update () {
		//if(Input.GetKeyDown(KeyCode.Return)){
 			firstPlayer = player1.text.ToString ();
			secondPlayer = player2.text.ToString ();

			//print (x);

		}
    }




