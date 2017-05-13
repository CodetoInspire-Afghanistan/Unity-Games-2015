using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BadTextController1 : MonoBehaviour {

    public Text text;
    // public SpriteRenderer spriteRenderer;
    private enum States {content,Aa,Bb,Cc,Dd,Ee,Ff,Gg,Hh,Ii,Jj,Kk,Ll,Mm,Nn,Oo,Pp,Qq,Rr,Ss,Tt,Uu,Vv,Ww,Xx,Yy,Zz};
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
        } else if (myState == States.Jj) {
            state_Jj();
        } else if (myState == States.Kk) {
            state_Kk();
        } else if (myState == States.Ll) {
            state_Ll();
        } else if (myState == States.Mm) {
            state_Mm();
        } else if (myState == States.Nn) {
            state_Nn();
        }else if (myState == States.Oo) {
            state_Oo();
        }else if (myState == States.Pp) {
            state_Pp();
        }else if (myState == States.Qq) {
            state_Qq ();
        }else if (myState == States.Rr) {
            state_Rr ();
        }else if (myState == States.Ss) {
            state_Ss();
        }else if (myState == States.Tt) {
            state_Tt();
        }else if (myState == States.Uu) {
            state_Uu();
        }else if (myState == States.Vv) {
            state_Vv ();
        }else if (myState == States.Ww) {
            state_Ww();
        }
        else if (myState == States.Xx) {
            state_Xx();
        }else if (myState == States.Yy) {
            state_Yy ();
        }else if (myState == States.Zz) {
            state_content ();
        }
    }
    public void state_content() {
        text.text = ("Press from A to Z");

        if (Input.GetKeyDown(KeyCode.A)) {
            myState = States.Aa;
        }
    }
    public void state_Aa() {
        text.text =  ("A-Hyporisy");
        print("A");
        if (Input.GetKeyDown(KeyCode.B)) {
            myState = States.Bb;

        }
    }

    void state_Bb() {
        print("B");

        text.text =  ("B-Back bite ");
        if (Input.GetKeyDown(KeyCode.C)) {
            myState = States.Cc;

        }
    }

    void state_Cc() {
        print("C");

        text.text = ("C-Arrogance");
        if (Input.GetKeyDown(KeyCode.D)) {
            myState = States.Dd;

        }
    }
    void state_Dd() {
        print("D");

        text.text = ("D-Accuse");
        if (Input.GetKeyDown(KeyCode.E)) {
            myState = States.Ee;

        }
    }
    void state_Ee() {
        print("E");

        text.text =  ("E-Shrek turning to God");

        if (Input.GetKeyDown(KeyCode.F)) {
            myState = States.Ff;

        }
    }
    void state_Ff() {
        print("F");

        text.text =  (" F-Stealing");

        if (Input.GetKeyDown(KeyCode.G)) {
            myState = States.Gg;


        }
    }
    void state_Gg() {
        print("G");

        text.text =  ("G-Lying");

        if (Input.GetKeyDown(KeyCode.H)) {
            myState = States.Hh;


        }
    }

    void state_Hh() {
        print("H");

        text.text =  ("H-Following the devil");

        if (Input.GetKeyDown(KeyCode.I)) {
            myState = States.Ii;


        }
    }

    void state_Ii() {
        print("I");

        text.text = ("I-Greed");

        if (Input.GetKeyDown(KeyCode.J)) {
            myState = States.Jj;


        }
    }

    void state_Jj() {
        print("J");

        text.text =  ("J-Jealousy");

        if (Input.GetKeyDown(KeyCode.K)) {
            myState = States.Kk;


        }
    }


    void state_Kk() {
        print("K");

        text.text = ("K-Cruelty against people");

        if (Input.GetKeyDown(KeyCode.L)) {
            myState = States.Ll;


        }
    }


    void state_Ll() {
        print("L");

        text.text =  ("L-Devouring of the orphan");

        if (Input.GetKeyDown(KeyCode.M)) {
            myState = States.Mm;


        }
    }


    void state_Mm() {
        print("M");

        text.text = (" M-Unawareness from prayer");

        if (Input.GetKeyDown(KeyCode.N)) {
            myState = States.Nn;


        }
    }

    void state_Nn() {
        print("N");

        text.text = ("N-Apart from the devil's curse");

        if (Input.GetKeyDown(KeyCode.O)) {
            myState = States.Oo;


        }
    }

    void state_Oo(){
        print("O");

        text.text =  (" O-Profit-seeking");

        if(Input.GetKeyDown(KeyCode.P)){
            myState = States.Pp;


        }}


    void state_Pp(){
        print("P");

        text.text =  (" P-Reproach");

        if(Input.GetKeyDown(KeyCode.Q)){
            myState = States.Qq;


        }}



    void state_Qq(){
        print("Q");

        text.text =  (" Q-Taunt");

        if(Input.GetKeyDown(KeyCode.R)){
            myState = States.Rr;


        }}


    void state_Rr(){
        print("R");

        text.text = (" R-Persecuted people");

        if(Input.GetKeyDown(KeyCode.S)){
            myState = States.Ss;


        }}
    void state_Ss(){
        print("S");

        text.text =  (" S-Bribery");

        if(Input.GetKeyDown(KeyCode.T)){
            myState = States.Tt;


        }}



    void state_Tt(){
        print("T");

        text.text =  ("T-Violated the human rights of the oppressed");

        if(Input.GetKeyDown(KeyCode.U)){
            myState = States.Uu;


        }}


    void state_Uu(){
        print("U");

        text.text =  (" U-Insulting");

        if(Input.GetKeyDown(KeyCode.V)){
            myState = States.Vv;


        }}


    void state_Vv(){
        print("V");

        text.text = ("V-Indifferent in matters of religion");

        if(Input.GetKeyDown(KeyCode.W)){
            myState = States.Ww;


        }}


    void state_Ww(){
        print("W");

        text.text = (" W-Unaware of the rights of parents");

        if(Input.GetKeyDown(KeyCode.X)){
            myState = States.Xx;


        }}



    void state_Xx(){
        print("X");

        text.text =  (" X-Injustice");

        if(Input.GetKeyDown(KeyCode.Y)){
            myState = States.Yy;


        }}


    void state_Yy(){
        print("Y");

        text.text =  ("Y-To consider the things as halal while it is Unlawful");

        if(Input.GetKeyDown(KeyCode.Z)){
            myState = States.content;


        }}
}
