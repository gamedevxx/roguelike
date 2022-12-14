using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight2 : StateMachineBehaviour
{
    
    private BossController _bossController;
    private MonsterMeleeAttack _meleeAttack;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        _bossController = animator.GetComponent<BossController>();
        _meleeAttack = animator.GetComponent<MonsterMeleeAttack>();
        _meleeAttack.damage *= 2;
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossController.UpdateSprite();
        
        if (_bossController.NotTooNear())
        {
            animator.SetTrigger("BackToIdle");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _meleeAttack.damage /= 2;
        animator.ResetTrigger("BackToIdle");
    }
}
