using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
    private static bool y=false;
    private AudioSource myMusic;
    public AudioClip A;
   public AudioClip B;
 	// Use this for initialization
    void Awake(){

    }
	void Start () {
	if (y){
        Destroy(gameObject);
    }else {
        y=true;
        DontDestroyOnLoad(gameObject);
        myMusic=this.GetComponent<AudioSource>();
        GameObject.DontDestroyOnLoad(myMusic);
        myMusic.Play();
        myMusic.clip=A;
        myMusic.loop=true;

    }
	}
	void OnLevelWasLoaded(int Level){
         myMusic=this.GetComponent<AudioSource>();

       //myMusic.Stop();
       if (Level==0 ||Level==3){
            myMusic.clip=A;
           myMusic.Play();
           myMusic.loop = true;

       }
         if (  Level==1 || Level==5){

            myMusic.clip=B;
            myMusic.Play();
            myMusic.loop = true;

        }


  }

}
