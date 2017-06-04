using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    [SerializeField]
    private float xMax;

    [SerializeField]
    private float yMax;
    [SerializeField]
    private float xMin;
    //[SerializeField]
	public float yMin;
    private Transform target;



	void Update(){
		target = GameObject.Find("Player").transform;
	}

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);
    }



}
