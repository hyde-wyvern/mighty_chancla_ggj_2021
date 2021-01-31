using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpScare : StateMachineBehaviour
{
    private EnemyAI ai;
    private Animator anim;
    private float timer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ai = animator.gameObject.GetComponent<EnemyAI>();
        anim = animator;
        ai.JumpScare();
        timer = 0.5f;
        animator.gameObject.GetComponent<SphereCollider>().enabled = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = timer - (1 * Time.deltaTime);

        if (timer <= 0)
        {
            anim.SetBool("jumpScare", false);
        }

        ai.JumpScare();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<SphereCollider>().enabled = true;
    }
}