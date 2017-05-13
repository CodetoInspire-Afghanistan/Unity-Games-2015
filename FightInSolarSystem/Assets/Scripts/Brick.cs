using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour {

    private int maxHits;
    private int hits;
    public Sprite[] hitSprites;
    static bool isBreakable=false;
    public AudioClip crack;
    public static bool heart=false;
    bool selfDestroyed = false;
    public static bool ghoulInstantiated = false;
    private SceneManager sceneManager;
    public static int  breakableCount=0;
    private  ScoreKeeper scoreKeeper;
    public GameObject SmokePuff;
    public GameObject coin;
    public GameObject coin2;
    public GameObject monster;
    public  GameObject unBreak;
    public Slider slider;


    void Start () {
      Slider slider = this.GetComponent<Slider>();
        scoreKeeper = GameObject.FindObjectOfType<ScoreKeeper>();
        isBreakable = (this.CompareTag("Breakable"));

                if (isBreakable) {
                    breakableCount++;
                    print(breakableCount);
                }
        sceneManager = GameObject.FindObjectOfType<SceneManager>();
        hits = 0;
        maxHits = hitSprites.Length + 1;
    }



    // Update is called once per frame
    void Update () {

        if (slider){
            slider.value-=Time.deltaTime*0.0033f;
            if(slider.value==0){
                if (!selfDestroyed){
                    Destroy(gameObject);
                    selfDestroyed = true;
                    breakableCount--;

                }
               // print(breakableCount);
        }
        }
    }


    void OnCollisionEnter2D(Collision2D other) {
         AudioSource.PlayClipAtPoint(crack,transform.position,1f);
        if(isBreakable){
             HandHits();
        }
    }



    void HandHits(){
        hits++;
         if (hits >= maxHits) {
            breakableCount--;
             GameObject smoke=Instantiate(SmokePuff,this.transform.position+new Vector3(0,0,-3),Quaternion.identity) as GameObject;
             smoke.GetComponent<ParticleSystem>().startColor=this.GetComponent<SpriteRenderer>().color;
             Destroy(gameObject);


            if (coin){
                scoreKeeper.add(5);
                ScoreKeeper.x+=5;
              }
            else if (coin2) {
                scoreKeeper.add(3);
                ScoreKeeper.x+=3;
            }
            else if (monster) {
                scoreKeeper.add(10);
                ScoreKeeper.x+=10;
            }
           else{
               scoreKeeper.add(1);
                ScoreKeeper.x++;
             }

            sceneManager.brickDestroyed();
        }
         else{
            int spriteIndex = hits - 1;
            if (hitSprites[spriteIndex]){
                this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
            }
        }
    }
}
