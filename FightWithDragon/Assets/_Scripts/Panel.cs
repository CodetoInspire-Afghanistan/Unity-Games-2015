using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Panel : MonoBehaviour {
    private EnemySpownerLevel2 enemy;
    private Destroy2 enemy2;

    private Animator animator;

    // Use this for initialization
    void Start () {
        enemy = GameObject.FindObjectOfType<EnemySpownerLevel2>();
        enemy2 = GameObject.FindObjectOfType<Destroy2>();

        animator = GetComponent<Animator>();
    }

    //Update is called once per frame
    void Update () {
        if (ScoreKeeper.x >= 1000 ) {
            enemy.DestroyMembers();
            //d2.GetComponent<Destroy2>().DestroyMembers();
            if(SceneManager.currentSceneIndex==5 || SceneManager.currentSceneIndex==6 || SceneManager.currentSceneIndex==7 ){
                enemy2.DestroyMembers();
            }
            animator.SetTrigger("move");
            ScoreKeeper.x = 0;

        }



    }



}
