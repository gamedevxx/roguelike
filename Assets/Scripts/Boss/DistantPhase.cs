using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistantPhase : BasePhase
{
    private Animator _animator;
    private MonsterMeleeAttack _meleeAttack;
    private MonsterDistantAttack _distantAttack;
    private FastDistantAttack _fastDistantAttack;
    private BossController _bossController;
    
    public Projectile projectile;
    public Projectile fastProjectile;
    public float damage = 10;
    public float distantTimeOut = 10;
    public float fastDistantTimeOut = 10;

    public float minDistance = 4;
    
    
    void Start()
    {
        enabled = false;
    }
    public override void StartPhase()
    {
        _animator = GetComponent<Animator>();
        
        _bossController = GetComponent<BossController>();
        _bossController.minDistance = minDistance;
        

        _animator.SetTrigger("BackToIdle");
        AddAttack();
        
    }

    public override void AddAttack()
    {
        _meleeAttack = gameObject.AddComponent<MonsterMeleeAttack>();
        _meleeAttack.damage = damage;
        _distantAttack = gameObject.AddComponent<MonsterDistantAttack>();
        _distantAttack.projectile = projectile;
        _distantAttack.timeout = distantTimeOut;
        _fastDistantAttack = gameObject.AddComponent<FastDistantAttack>();
        _fastDistantAttack.projectile = fastProjectile;
        _fastDistantAttack.timeout = fastDistantTimeOut;
    }
    
    public override void RemoveAttack()
    {
        Destroy(_distantAttack);
        Destroy(_meleeAttack);
        Destroy(_fastDistantAttack);
    }
    
    public override void EndPhase()
    {
        _animator.SetTrigger("BackToIdle");
        RemoveAttack();
    }

}