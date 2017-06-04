using UnityEngine;
using System.Collections;
using System;

public class Ladder : MonoBehaviour,IUseable
{
    /// <summary>
    /// A reference to the platformcollider
    /// </summary>
    [SerializeField]
    private Collider2D platformCollider;

	
    /// <summary>
    /// When the ladder is used
    /// </summary>
    public void Use()
    {
        if (Player.Instance.OnLadder) 
        {
            //We need to stop climbing
            UseLadder(false, 1,0,1,"land");
        }
        else
        {
            //We need to climb
            UseLadder(true, 0,1,0,"reset");

            //Ignores the collision between the player and the platform
            Physics2D.IgnoreCollision(Player.Instance.GetComponent<Collider2D>(), platformCollider, true);
        }
       
    }

    /// <summary>
    /// Whent he player jumps off the ladder
    /// </summary>
    private void OnTriggerExit2D(Collider2D other)
    {
        UseLadder(false, 1,0,1,"land"); //jumps off the ladder

        //Stops ignoring the collision between the player and the platform
        Physics2D.IgnoreCollision(Player.Instance.GetComponent<Collider2D>(), platformCollider, false);
    }

    /// <summary>
    /// Function called when we use call use on the ladder
    /// </summary>
    /// <param name="onLadder">do we need to be on or off the ladder</param>
    /// <param name="gravityScale">The players gravity scale</param>
    /// <param name="layerWeight">The weight on the climb layer</param>
    /// <param name="animSpeed">The animation speed, 0 for climbin, 1 for off </param>
    /// <param name="trigger">Animation trigger to activate</param>
    private void UseLadder(bool onLadder, int gravityScale,int layerWeight, int animSpeed, string trigger)
    {
        Player.Instance.OnLadder = onLadder;
        Player.Instance.MyRigidbody.gravityScale = gravityScale;
        Player.Instance.MyAnimator.SetLayerWeight(2, layerWeight);
        Player.Instance.MyAnimator.speed = animSpeed;
        Player.Instance.MyAnimator.SetTrigger(trigger);
    }
}
