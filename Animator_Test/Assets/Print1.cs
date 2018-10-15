using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Print1 : StateMachineBehaviour {

    private GameObject CUGO;
    private float timer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.CUGO = GameObject.Find("CU");
        this.timer = 3.0f;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //timer -= Time.deltaTime;
        //if(timer < 0.0f)
        //{
        //    animator.SetTrigger("Next");
        //    Debug.Log("print1ani");
        //    //Debug.Log("timer" + timer);
        //    timer = 3.0f;
        //}
        int counter = 0;
        //while(true)
        //{
        //    counter += 1;
        //    Debug.Log("counter " + counter);
        //}

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
