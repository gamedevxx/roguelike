using System;
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
    private bool _isRoll;

    public int countOfRollAttack = 10;
    
    [NonSerialized]
    public int currRollAttack;

    public float rollTime = 7;
    private float _currRollTime;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        
        _bossController = GetComponent<BossController>();
        _lastAttackTime = Time.time - attackTimeout;
    }

    private void Update()
    {
        if (_isRoll && currRollAttack > countOfRollAttack)
        {
            _currRollTime += Time.deltaTime;
            if (_currRollTime > rollTime)
            {
                EndRoll();
            }
        }

        if (_isRoll || _lastAttackTime + attackTimeout > Time.time)
        {
            return;
        }

        StartRoll();
    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Env") && !col.gameObject.CompareTag("Player"))
        {
            return;
        }
        if (col.gameObject.CompareTag("Env") && currRollAttack > countOfRollAttack)
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
        

        if (currRollAttack > countOfRollAttack)
        {
            EndRoll();
        }
        else
        {
            StartRoll();
        }
    }
    


    private void StartRoll()
    {

        _isRoll = true;
        if (currRollAttack == countOfRollAttack)
        {
            _bossController.movementTrigger = "StartRoll";
        }
        else
        {
            _bossController.movementTrigger = "StartSimpleRoll";
        }
        _animator.SetTrigger("BackToIdle");
    }

    private void EndRoll()
    {
        _currRollTime = 0;
        currRollAttack = 0;
        _lastAttackTime = Time.time;
        _bossController.movementTrigger = "StartRun";
        _animator.SetTrigger("BackToIdle");
        _isRoll = false;
    }
}
