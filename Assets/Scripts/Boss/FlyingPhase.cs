using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPhase : BasePhase
{
    private Animator _animator;
    private MultiplyDistantAttack _multiplyDistantAttack;
    private MonsterDistantAttack _distantAttack;
    private BossController _bossController;
    
    public Projectile multiplyProjectile;
    public Projectile homingProjectile;
    public int countOfProjectiles = 3;
    public float rotationAngle = 30;
    public float multiplyTimeOut = 5;
    public float homingTimeOut = 10;
    
    public float minDistance = 4;
    
    
    void Start()
    {
        this.enabled = false;
    }
    public override void StartPhase()
    {
        _animator = GetComponent<Animator>();
        
        _bossController = GetComponent<BossController>();
        _bossController.minDistance = minDistance;
        
        _bossController.isStop = true;
        _animator.SetTrigger("BackToIdle");
        _animator.SetTrigger("StartFly");
        
    }

    public override void AddAttack()
    {
        _multiplyDistantAttack = gameObject.AddComponent<MultiplyDistantAttack>();
        _multiplyDistantAttack.projectile = multiplyProjectile;
        _multiplyDistantAttack.rotationAngle = rotationAngle;
        _multiplyDistantAttack.countOfProjectiles = countOfProjectiles;
        _multiplyDistantAttack.timeout = multiplyTimeOut;

        _distantAttack = gameObject.AddComponent<MonsterDistantAttack>();
        _distantAttack.projectile = homingProjectile;
        _distantAttack.timeout = homingTimeOut;
    }
    
    public override void RemoveAttack()
    {
        Destroy(_multiplyDistantAttack);
        Destroy(_distantAttack);
    }
    
    public override void EndPhase()
    {
        _bossController.isStop = false;
        _animator.SetTrigger("BackToIdle");
    }

}
