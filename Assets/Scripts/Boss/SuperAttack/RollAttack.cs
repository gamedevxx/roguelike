using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollAttack : MonoBehaviour
{
    private BossController _bossController;
    private Animator _animator;
    public float damage = 10;
    public float attackTimeout = 1;
    
    private float _lastAttackTime;
    private bool _isRoll = false;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        
        _bossController = GetComponent<BossController>();
        _lastAttackTime = Time.time - attackTimeout;
    }

    private void Update()
    {
        if (_isRoll)
        {
            return;
        }
        if (_lastAttackTime + attackTimeout > Time.time)
        {
            return;
        }

        _isRoll = true;
        _bossController.movementTrigger = "StartRoll";
        _animator.SetTrigger("BackToIdle");
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Env") && !col.gameObject.CompareTag("Player"))
        {
            return;
        }
        if (!_isRoll)
        {
            return;
        }
        
        PlayerTag player = col.gameObject.GetComponent<PlayerTag>();

        if (player != null)
        {
            CreatureBody playerBody = player.GetComponent<CreatureBody>();
            playerBody.Damage(damage);
        }

        _isRoll = false;
        _bossController.movementTrigger = "StartRun";
        _animator.SetTrigger("BackToIdle");

        _lastAttackTime = Time.time;
    }
}
