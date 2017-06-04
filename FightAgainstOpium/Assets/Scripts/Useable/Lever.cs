using UnityEngine;
using System.Collections;
using System;

public class Lever : MonoBehaviour, IUseable {

    /// <summary>
    /// A reference to the platform that the lever is controlling
    /// </summary>
    [SerializeField]
    private Transform platform;

    /// <summary>
    /// The movement speed of the platform
    /// </summary>
    [SerializeField]
    private float speed;

    /// <summary>
    /// The end position of the platform
    /// </summary>
    private Vector3 firstPos;

    /// <summary>
    /// The second position of the platform
    /// </summary>
    [SerializeField]
    private Vector3 secondPos;

    /// <summary>
    /// A reference to the lever's animator
    /// This is used for the flip animation
    /// </summary>
    private Animator animator;

    /// <summary>
    /// Indicated if we need to move towards the second positoin
    /// </summary>
    private bool moveToSecond = false;

    // Use this for initialization
    void Start ()
    {
		print (gameObject);
        //Creates the reference to the animator
        animator = GetComponent<Animator>();

        //Sets the firstPos to the start positoin
        firstPos = platform.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (moveToSecond) //If we need to move to the second position
        {
            platform.transform.localPosition = Vector2.MoveTowards(platform.transform.localPosition, secondPos, speed * Time.deltaTime);
        }
        else if (!moveToSecond) //If we need to move to the third position
        {
            platform.transform.localPosition = Vector2.MoveTowards(platform.transform.localPosition, firstPos, speed * Time.deltaTime);
        }
        
	}

    /// <summary>
    /// Uses the lever
    /// </summary>
    public void Use()
    {
        moveToSecond = !moveToSecond; //Reverses the position
        animator.SetTrigger("pull"); //Triggers the pull animation
    }

    /// <summary>
    /// Sets the player as a child object of the platform, so that it follows the platform while moving
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.SetParent(platform.transform);
        }
    }

    /// <summary>
    /// Removes the player as a child object to the platform
    /// </summary>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.SetParent(null);
        }
    }
}
