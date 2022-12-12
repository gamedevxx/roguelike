using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossIdle : StateMachineBehaviour
{
    private BossController _bossController;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("BackToIdle");
        _bossController = animator.GetComponent<BossController>();
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (!_bossController.isStop)
        {
            if (!_bossController.NotTooNear())
            {
                _bossController.UpdateSprite();
                animator.SetTrigger("StartFight");
            }
            else if (_bossController.MovingCondition())
            {
                animator.SetTrigger(_bossController.movementTrigger);
            }
        }
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("BackToIdle");
        animator.ResetTrigger("StartFight");
        animator.ResetTrigger(_bossController.movementTrigger);
    }
    
}
