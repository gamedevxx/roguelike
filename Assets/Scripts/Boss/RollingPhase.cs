using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingPhase : BasePhase
{
    private MonsterMeleeAttack _meleeAttack;
    private RollAttack _rollAttack;
    private MultiplyDistantAttack _distantAttack;
    
    private BossController _bossController;
    private Animator _animator;
    

    public float meleeDamage = 15;
    public float rollDamage = 30;
    public float rollTimeout = 5;
    public float poisonTimeout = 5;
    public Projectile projectile;
    
    public int countOfProjectiles = 12;

    public float rotationAngle = 30;
    
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
        _meleeAttack.damage = meleeDamage;
        _rollAttack = gameObject.AddComponent<RollAttack>();
        _rollAttack.damage = rollDamage;
        _rollAttack.attackTimeout = rollTimeout;
        _distantAttack = gameObject.AddComponent<MultiplyDistantAttack>();
        _distantAttack.projectile = projectile;
        _distantAttack.timeout = poisonTimeout;
        _distantAttack.rotationAngle = rotationAngle;
        _distantAttack.countOfProjectiles = countOfProjectiles;

    }

    public override void RemoveAttack()
    {
        Destroy(_meleeAttack);
        Destroy(_rollAttack);
        Destroy(_distantAttack);
    }
    
    public override void EndPhase()
    {
        _animator.SetTrigger("BackToIdle");
        RemoveAttack();
    }
}
