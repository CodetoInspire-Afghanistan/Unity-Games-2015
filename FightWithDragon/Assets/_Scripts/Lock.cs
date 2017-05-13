using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Lock : MonoBehaviour {
    public string name;
    public Sprite spriteRenderer;
    private  SceneManager sceneManager;
    //private  Panel panel;
    // Use this for initialization
    void Start () {
        sceneManager=GameObject.FindObjectOfType<SceneManager>();


    }

    // Update is called once per frame
    void Update () {
        if (ScoreKeeper.score >=0) {
            if ( gameObject.CompareTag("Level_1")) {
                this.GetComponent<SpriteRenderer>().sprite=spriteRenderer;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                Add.projectile=250;
            }
        }
        if (ScoreKeeper.score >= 1000) {
            if ( gameObject.CompareTag("Level_2")) {
                this.GetComponent<SpriteRenderer>().sprite=spriteRenderer;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                Add.projectile=250;
            }
        }

        if (ScoreKeeper.score >= 2000) {
            if ( gameObject.CompareTag("Level_3")) {
                this.GetComponent<SpriteRenderer>().sprite=spriteRenderer;

                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                Add.projectile=250;

            }
        }

        if (ScoreKeeper.score >= 3000) {
            if ( gameObject.CompareTag("Level_4")) {
                this.GetComponent<SpriteRenderer>().sprite=spriteRenderer;

                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                Add.projectile=250;

            }
        }

        if (ScoreKeeper.score >= 4000) {
            if ( gameObject.CompareTag("Level_5")) {
                this.GetComponent<SpriteRenderer>().sprite=spriteRenderer;

                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                Add.projectile=250;

            }
        }

      
        }

    void OnMouseDown() {
        sceneManager.LoadScene(name);
     }
}
