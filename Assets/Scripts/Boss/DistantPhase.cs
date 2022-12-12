using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistantPhase : BasePhase
{
    private Animator _animator;
    private MonsterMeleeAttack _meleeAttack;
    private MonsterDistantAttack _distantAttack;
    private BossController _bossController;
    
    public Projectile projectile;
    public float damage = 10;
    
    
    void Start()
    {
        this.enabled = false;
    }
    public override void StartPhase()
    {
        _animator = GetComponent<Animator>();
        
        _bossController = GetComponent<BossController>();
        _bossController.minDistance = 2;
        

        _animator.SetTrigger("BackToIdle");
        AddAttack();
        
    }

    public override void AddAttack()
    {
        _meleeAttack = gameObject.AddComponent<MonsterMeleeAttack>();
        _meleeAttack.damage = damage;
        _distantAttack = gameObject.AddComponent<MonsterDistantAttack>();
        _distantAttack.projectile = projectile;
    }
    
    public override void RemoveAttack()
    {
        Destroy(_distantAttack);
        Destroy(_meleeAttack);
    }
    
    public override void EndPhase()
    {
        _animator.SetTrigger("BackToIdle");
        RemoveAttack();
    }

}