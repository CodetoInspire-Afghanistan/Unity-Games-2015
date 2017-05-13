using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public bool autoPlay =false;
    private  Stone stone;
    // Use this for initialization
    void Start () {
        stone=GameObject.FindObjectOfType<Stone>();
    }
    void Update () {
        if( !autoPlay){
            MoveWithMouse();
        }else
            AutoPlay();
    }
    void MoveWithMouse(){
        Vector3 paddlePosition = this.transform.position;
        float mousePosition = Input.mousePosition.x / Screen.width * 16;
        paddlePosition.x = Mathf.Clamp (mousePosition,1.93f,14.11f);
        this.transform.position = paddlePosition;
    }
    void  AutoPlay(){
        Vector3 paddlePosition = new Vector3(stone.transform.position.x,transform.position.y , transform.position.z);
        transform.position=paddlePosition;
    }

    }



