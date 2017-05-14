using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Panel : MonoBehaviour {

    private Animator animator;
    private  RandomNumber randomNumber;
      string getNumber;


    // Use this for initialization
    void Start () {
        randomNumber=GameObject.FindObjectOfType<RandomNumber>() as RandomNumber;

        animator = GetComponent<Animator>();

    }

    void Update () {
         if (Input.GetKeyDown (KeyCode.Return)) {

            getNumber = randomNumber.findNumber.text.ToString ();


        }

        if (getNumber!=null){
            animator.SetTrigger("reset");
        }



    }



}
