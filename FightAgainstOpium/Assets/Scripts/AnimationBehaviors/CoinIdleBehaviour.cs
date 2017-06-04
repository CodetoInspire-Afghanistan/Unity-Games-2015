using UnityEngine;
using System.Collections;

public class CoinIdleBehaviour : StateMachineBehaviour
{

    /// <summary>
    /// The time that the coin will idle in seconds
    /// </summary>
    private float idleTime = 5;

    /// <summary>
    /// The current elapsed time
    /// </summary>
    private float elapsed;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Resets the elapsed time, so that we dont loop
        elapsed = 0;
        animator.ResetTrigger("Blink");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        elapsed += Time.deltaTime;

        if (elapsed >= idleTime) //If the elapsed time is higher than idle time, then we dont need to idle
        {
            animator.SetTrigger("Blink");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
