using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    private static bool y = false;
    private AudioSource myMusic;
    public AudioClip A;
    public AudioClip B;
    public AudioClip C;
    public AudioClip D;
    // Use this for initialization
    void Awake() {

    }
    void Start () {
        if (y) {
            Destroy(gameObject);
        } else {
            y = true;
            DontDestroyOnLoad(gameObject);
            myMusic = this.GetComponent<AudioSource>();
            GameObject.DontDestroyOnLoad(myMusic);
            myMusic.Play();
            myMusic.clip = A;
            //myMusic.loop=true;

        }
    }
    void OnLevelWasLoaded(int Level) {
        myMusic = this.GetComponent<AudioSource>();

        //myMusic.Stop();


        if (Level == 0 || Level == 2) {
            myMusic.clip = A;
            myMusic.Play();
            myMusic.loop = true;
        }
        if (Level == 3 || Level == 4 || Level == 5 || Level == 6 || Level == 7) {
            myMusic.clip = B;
            myMusic.Play();
            myMusic.loop = true;

        }
        if (Level == 9) {
            myMusic.clip = C;
            myMusic.Play();
            myMusic.loop = true;
        }

        if (Level == 8) {
            myMusic.clip = D;
            myMusic.Play();
            myMusic.loop = true;
        }


    }
    void Update () {

    }
}
