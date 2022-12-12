using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStartBig : StateMachineBehaviour
{
    private BossController _bossController;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossController = animator.GetComponent<BossController>();
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bossController.isStop = false;
    }
    
}
