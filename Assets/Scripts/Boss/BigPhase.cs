using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPhase : BasePhase
{
    private MonsterMeleeAttack _meleeAttack;
    private MonsterDistantAttack _distantAttack;
    private JumpAttack _jumpAttack;
    private BossController _bossController;
    private Animator _animator;
    
    public Projectile projectile;
    
    
    public float damage = 10;
    public float radius = 5;
    public float timeForJump = 5;
    
    
    void Start()
    {
        enabled = false;
    }


    public override void StartPhase()
    {
        _animator = GetComponent<Animator>();
        
        _bossController = GetComponent<BossController>();
        _bossController.minDistance = 1;
        
        _bossController.isStop = true;
        _animator.SetTrigger("BackToIdle");
        _animator.SetTrigger("StartBig");

        AddAttack();
        
    }
    
    public override void AddAttack()
    {
        _meleeAttack = gameObject.AddComponent<MonsterMeleeAttack>();
        _meleeAttack.damage = damage;
        _distantAttack = gameObject.AddComponent<MonsterDistantAttack>();
        _distantAttack.projectile = projectile;
        _jumpAttack = gameObject.AddComponent<JumpAttack>();

    }

    public override void RemoveAttack()
    {
        Destroy(_meleeAttack);
        Destroy(_distantAttack);
        Destroy(_jumpAttack);
    }
    
    public override void EndPhase()
    {
        _animator.SetTrigger("BackToIdle");
        RemoveAttack();
    }
}