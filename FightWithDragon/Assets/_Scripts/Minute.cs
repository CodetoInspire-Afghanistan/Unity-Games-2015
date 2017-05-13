using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Minute : MonoBehaviour {

    public int start = 0;
    public int end = 5;
    public int sceneNumber;


    // Use this for initialization
    void Start () {
        InvokeRepeating("decreaseTime", 1f, 1f);



    }

    // Update is called once per frame
    void Update () {
        if (start == end ) {
            NextLevel();

        }
    }


    void decreaseTime() {
        start += 1;
        print(start);
    }

    void NextLevel() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNumber);


    }
}
