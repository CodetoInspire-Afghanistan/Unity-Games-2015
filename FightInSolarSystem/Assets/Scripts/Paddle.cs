using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Paddle : MonoBehaviour {
    public   bool autoPlay=false;
    private  Ball ball;
  //  bool hasStarted=false;

    void Start ( ) {
         ball=GameObject.FindObjectOfType<Ball>();

     }
    void Update ( ) {
        if (!autoPlay){
             MoveWithMouse();
        }
        else{
            AutoPlay( );
        }
    }
    void MoveWithMouse(){

        Vector3 paddlePosition = this.transform.position;
        float mousePositionInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlePosition.x = Mathf.Clamp(mousePositionInBlocks, 0.98f, 15.05f) ;
        this.transform.position = paddlePosition;
    }

    void  AutoPlay(){
    float newPaddleXPosition=Mathf.Clamp(ball.transform.position.x,0.98f,15.05f);
        Vector3 newPaddlePosition = new Vector3(newPaddleXPosition,
        transform.position.y, transform.position.z);
        transform.position = newPaddlePosition;
    }

}