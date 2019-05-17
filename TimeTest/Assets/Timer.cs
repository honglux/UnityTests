using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : StateMachineBehaviour
{
    private TimeTest TT_script;

    private float ani_timer;
    private bool ani_timer_flag;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(TT_script == null)
        {
            TT_script = animator.GetComponent<TimeTest>();
        }

        ani_timer = 0.0f;
        ani_timer_flag = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        TT_script.ani_timer = ani_timer;
        if(ani_timer_flag)
        {
            ani_timer -= Time.deltaTime;
            if(ani_timer < 0.0f)
            {
                ani_timer_flag = false;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}

    public void start_timer()
    {
        ani_timer_flag = true;
    }

    public void reset_timer()
    {
        ani_timer = TT_script.TestTime;
        ani_timer_flag = true;
    }
}
