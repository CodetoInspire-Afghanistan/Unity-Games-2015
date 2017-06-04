using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour
{
    
    [SerializeField]
    private Transform platformTransform;

    
    [SerializeField]
    private Transform transformB;
private Vector3 posA;

    private Vector3 posB;

    private Vector3 nextPos;

    [SerializeField]
    private float movementSpeed;

    // Use this for initialization
    void Start()
    {
        posA = platformTransform.localPosition;
        posB = transformB.localPosition;
        nextPos = posB;
    }

    // Update is called once per frame
    void Update()
    {
        platformTransform.localPosition = Vector3.MoveTowards(platformTransform.localPosition, nextPos, movementSpeed * Time.deltaTime);

        if (Vector3.Distance(platformTransform.localPosition, nextPos) <= 0.1)
        {
            ChangeDestination();
        }
    }

    private void ChangeDestination()
    {
        nextPos = nextPos != posA ? posA : posB;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.layer = 11; 
            other.transform.SetParent(platformTransform); 
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.SetParent(null);
        }
    }
}
