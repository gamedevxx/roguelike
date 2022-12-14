using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoll : StateMachineBehaviour
{
    private BossController _bossController;
    private Transform _transform;
    private RollAttack _rollAttack;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossController = animator.GetComponent<BossController>();
        _bossController.speed *= 2;
        
        _transform = animator.GetComponent<Transform>();

        _transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);
        _rollAttack = animator.GetComponent<RollAttack>();
        ++_rollAttack.currRollAttack;
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
