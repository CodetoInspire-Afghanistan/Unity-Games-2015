using UnityEngine;
using System.Collections;

public class Instantiate : MonoBehaviour {

    public  GameObject a;
    public  GameObject b;
    public  GameObject c;
    public  GameObject d;
    public  GameObject e;

    void OnCollisionEnter2D() {
        if (a){
        Instantiate(a,transform.position+new Vector3(3,2,0),Quaternion.identity);
        }
        if (b){
        Instantiate(b,transform.position+new Vector3(2,6,0),Quaternion.identity);

        }
        if (c){
            Instantiate(c,transform.position+new Vector3(-2,11,0),Quaternion.identity);

        } if (d){
            Instantiate(d,transform.position+new Vector3(-1,10,0),Quaternion.identity);

        }if (e){
            Instantiate(e,transform.position+new Vector3(2.5f,10,0),Quaternion.identity);

        }
    }

}
