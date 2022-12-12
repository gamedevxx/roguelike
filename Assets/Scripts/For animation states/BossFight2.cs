using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight2 : StateMachineBehaviour
{
    
    private BossController _bossController;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossController = animator.GetComponent<BossController>();
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossController.UpdateSprite();
        
        if (_bossController.NotTooNear())
        {
            animator.SetTrigger("BackToIdle");
        }
    }
}
