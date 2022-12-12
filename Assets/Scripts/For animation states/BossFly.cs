using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFly : StateMachineBehaviour
{
    private BossController _bossController;
    private MonsterDistantAttack _distantAttack;
    private FlyingPhase _flyingPhase;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("StartFly");
        
        _bossController = animator.GetComponent<BossController>();
        _bossController.z_rotation = 25f;

        _flyingPhase = animator.GetComponent<FlyingPhase>();
        _flyingPhase.AddAttack();

    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossController.UpdateSprite();
        
        if (_bossController.MovingCondition())
        {
            _bossController.Move();
        }
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossController.z_rotation = 0f;
        animator.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
        _flyingPhase.RemoveAttack();
    }


}
