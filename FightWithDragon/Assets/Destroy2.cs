using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Destroy2 : MonoBehaviour {
    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float minX;
    public float maxX;
    public float spawnDelay = 0.5f;

    // Use this for initialization
    void Start () {
        float distance = this.transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        minX = leftMost.x;
        maxX = rightMost.x;
        SpawnUntilFull();
    }





    void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }
    // Update is called once per frame
    void Update () {
        if (AllMembersAreDead()) {
            SpawnUntilFull();
        }
    }

    void SpawnUntilFull() {
        Transform freePosition = NextFreePosition();
        if (freePosition) {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.position + new Vector3(0, 0, -2), Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;


        }
        if ( gameObject.CompareTag("Another")) {
            Invoke("SpawnUntilFull", spawnDelay);
        }


        else   if (NextFreePosition()) {
            Invoke("SpawnUntilFull", spawnDelay);

        }

    }
    Transform NextFreePosition() {
        foreach (Transform childGameObjectPosition in transform) {
            if (childGameObjectPosition.childCount == 0) {
                return  childGameObjectPosition;
            }

        }
        return  null;


    }


    bool AllMembersAreDead() {
        foreach (Transform childGameObjectPosition in transform) {
            if (childGameObjectPosition.childCount > 0) {
                return  false;
            }
        }
        return  true;

    }

    public void DestroyMembers() {
        // foreach (Transform childGameObjectPosition in transform) {

        Destroy(this.gameObject);
        //}
    }



}


