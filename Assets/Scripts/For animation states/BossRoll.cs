using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoll : StateMachineBehaviour
{
    private BossController _bossController;
    private Transform _transform;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossController = animator.GetComponent<BossController>();
        _bossController.speed *= 2;
        
        _transform = animator.GetComponent<Transform>();

        _transform.localScale = new Vector3(1.5f, 1.5f, 1.0f);
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossController.UpdateSprite();
        
        if (!_bossController.MovingCondition())
        {
            animator.SetTrigger("BackToIdle");
        }

        _bossController.Move();
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossController.speed /= 2;
        _transform.localScale = new Vector3(1f, 1f, 1.0f);
        animator.ResetTrigger("BackToIdle");
        
    }


}
