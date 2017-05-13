using UnityEngine;
using System.Collections;

public class Bottles : MonoBehaviour {

    public int hits;
    public int maxHits;
   // private SceneManager sceneManager;
    public Sprite []hitSprites;
    public static int breakableCount = 0 ;
    bool isBreakable ;
    public AudioClip Break_Sound;
    private ScoreKeeper scorekeeper;



    void Start () {
        isBreakable = (this.CompareTag("Breakable"));
        if (isBreakable) {
            breakableCount++;

        }

        //sceneManager = GameObject.FindObjectOfType<SceneManager>();
        scorekeeper=GameObject.FindObjectOfType<ScoreKeeper>();
        hits = 0;
    }
    void OnCollisionEnter2D() {
        AudioSource.PlayClipAtPoint(Break_Sound, transform.position);
        if (isBreakable) {
            HandleHits();
        }
    }
    void HandleHits() {
        hits++;
        if (hits >= maxHits) {
            breakableCount--;
           // print(breakableCount);
            Destroy(this.gameObject);
            scorekeeper.IncreaseScore();



            //sceneManager.LoadNextLevel();
        } else {
            int spriteIndex = hits - 1;
            if (hitSprites[spriteIndex] != null) {
                this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
            }
        }
    }
}