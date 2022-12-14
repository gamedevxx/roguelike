using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSimpleRoll : StateMachineBehaviour
{
    
    private BossController _bossController;
    private Vector3 _direction;
    private RollAttack _rollAttack;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossController = animator.GetComponent<BossController>();
        _bossController.speed *= 4;
        _direction = _bossController.MovementDirection();
        _rollAttack = animator.GetComponent<RollAttack>();
        ++_rollAttack.currRollAttack;
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        _bossController.Move(_direction);
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossController.speed /= 4;
    }
    
}
