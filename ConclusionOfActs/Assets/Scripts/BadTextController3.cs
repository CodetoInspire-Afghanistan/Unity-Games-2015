using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BadTextController3 : MonoBehaviour {
    public Text text;
    // public SpriteRenderer spriteRenderer;
    private enum States {content,Aa,Bb,Cc,Dd,Ee,Ff,Gg,Hh,Ii};
    private States myState;

    void Start () {

        myState = States.content;
    }

    // Update is called once per frame
    void Update () {
        if (myState == States.content) {
            state_content();
        } else if (myState == States.Aa) {
            state_Aa();
        } else if (myState == States.Bb) {
            state_Bb();
        } else if (myState == States.Cc) {
            state_Cc();
        } else if (myState == States.Dd) {
            state_Dd();
        } else if (myState == States.Ee) {
            state_Ee();
        } else if (myState == States.Ff) {
            state_Ff();
        } else if (myState == States.Gg) {
            state_Gg();
        } else if (myState == States.Hh) {
            state_Hh();
        } else if (myState == States.Ii) {
            state_Ii();
        }
    }
    public void state_content() {
        text.text = ("Press from 0 to 9");

        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            myState = States.Aa;
        }
    }
    public void state_Aa() {
        print("0");

        text.text = ("0-Feel guilty ");

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            myState = States.Bb;

        }
    }

    void state_Bb() {
        print("1");


        text.text =  ("1-Bad example in society");
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            myState = States.Cc;

        }
    }

    void state_Cc() {
        print("2");

        text.text = (" 2-Being away from people ");
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            myState = States.Dd;

        }
    }
    void state_Dd() {
        print("3");

        text.text = (" 3-Lack of faith");
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            myState = States.Ee;

        }
    }
    void state_Ee() {
        print("4");

        text.text =  ("4-Get naughty friend");

        if (Input.GetKeyDown(KeyCode.Alpha5)) {
            myState = States.Ff;

        }
    }
    void state_Ff() {
        print("5");

        text.text =  ("5-Straying");

        if (Input.GetKeyDown(KeyCode.Alpha6)) {
            myState = States.Gg;


        }
    }
    void state_Gg() {
        print("6");

        text.text =  ("6-Losing Friends ");

        if (Input.GetKeyDown(KeyCode.Alpha7)) {
            myState = States.Hh;


        }
    }

    void state_Hh() {
        print("7");

        text.text = ("7-Away from mundane merits");

        if (Input.GetKeyDown(KeyCode.Alpha8)) {
            myState = States.Ii;


        }
    }

    void state_Ii() {
        print("8");

        text.text =  ("8-Prayer rejection");

        if (Input.GetKeyDown(KeyCode.Alpha9)) {
            myState = States.content;


        }
    }



}
