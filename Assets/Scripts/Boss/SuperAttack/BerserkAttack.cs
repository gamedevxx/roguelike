using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerserkAttack : MonoBehaviour
{
    private BossController _bossController;
    private Animator _animator;
    public float damage = 10;
    public float startAttackTimeout = 5;
    public float endAttackTimeout = 10;
    
    private float _currTime;
    private bool _isBerserk;
    void Start()
    {
        _animator = GetComponent<Animator>();
        
        _bossController = GetComponent<BossController>();
    }
    
    void Update()
    {
        _currTime += Time.deltaTime;
        
        if (!_isBerserk)
        {
            if (_currTime > startAttackTimeout)
            {
                _isBerserk = true;
                _bossController.movementTrigger = "StartBerserk";
                _animator.SetTrigger("BackToIdle");
                _currTime = 0;
            }
        }
        else
        {
            if (_currTime > endAttackTimeout)
            {
                _isBerserk = false;
                _bossController.movementTrigger = "StartRun";
                _animator.SetTrigger("BackToIdle");
                _currTime = 0;
            }
        }


    }
    
    private void OnTriggerStay2D(Collider2D col)
    {
        if (!_isBerserk)
        {
            return;
        }
        
        PlayerTag player = col.gameObject.GetComponent<PlayerTag>();

        if (player != null)
        {
            CreatureBody playerBody = player.GetComponent<CreatureBody>();
            playerBody.Damage(damage);
        }
        
    }
}
