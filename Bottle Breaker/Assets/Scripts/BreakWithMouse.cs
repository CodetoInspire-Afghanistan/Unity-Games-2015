using UnityEngine;
using System.Collections;

public class BreakWithMouse : MonoBehaviour {

    public AudioClip BreakSound;
    public AudioClip ErrorSound;
    private ScoreKeeper scoreKeeper;
    void Start(){
        scoreKeeper= GameObject.FindObjectOfType<ScoreKeeper>();
    }
 void OnMouseDown(){
     if (gameObject.CompareTag("Breakable")){
         Destroy(gameObject);
         AudioSource.PlayClipAtPoint(BreakSound, transform.position);
         scoreKeeper.IncreaseScore();}
         else if (gameObject.CompareTag("Cocacola")){
            scoreKeeper.DecreaseScore();
             AudioSource.PlayClipAtPoint(ErrorSound,transform.position);
         }



     }
 }

