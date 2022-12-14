using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossJump : StateMachineBehaviour
{
    private BossController _bossController;
    private JumpAttack _jumpAttack;
    private Vector3 _direction;
    private Vector3 _position;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        animator.ResetTrigger("StartJump");
        _bossController = animator.GetComponent<BossController>();
        _bossController.speed *= 4;
        _jumpAttack = animator.GetComponent<JumpAttack>();
        _position = _bossController.PlayerPosition();
        _direction = _bossController.MovementDirection(_position);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (_bossController.NotTooNear(_position))
        {
            _bossController.Move(_direction);
        }

    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _jumpAttack.DamagePlayer();
        _bossController.speed /= 4;
        animator.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
        _bossController.isStop = false;
    }


}
