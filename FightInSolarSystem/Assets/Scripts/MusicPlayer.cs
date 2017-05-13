using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    private static bool y=false;
    private AudioSource myMusic;
    public AudioClip A;
    public AudioClip B;
    public AudioClip C;
    public AudioClip D;
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
        if (Level==0 ||Level==3||Level==5 || Level==7 || Level==9 || Level==11 || Level==13 ||Level==15 ||Level==17 ){
            myMusic.clip=A;
            myMusic.Play();
            myMusic.loop = true;

        }
        if ( Level==2 ||Level==4||Level==6 || Level==8 || Level==10 || Level==12 || Level==14 ||Level==16 ||Level==18 || Level==19){

            myMusic.clip=B;
            myMusic.Play();
            myMusic.loop = true;

        }
        if (Level==20){
            myMusic.clip=C;
            myMusic.Play();
            myMusic.loop = true;

        }
        if (Level==21){
            myMusic.clip=D;
            myMusic.Play();
            myMusic.loop = true;

        }


    }
}
