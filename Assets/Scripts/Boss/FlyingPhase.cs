using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPhase : BasePhase
{
    private Animator _animator;
    private MultiplyDistantAttack _distantAttack;
    private BossController _bossController;
    
    public Projectile projectile;
    
    public int countOfProjectiles = 3;

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
        
        _bossController.isStop = true;
        _animator.SetTrigger("BackToIdle");
        _animator.SetTrigger("StartFly");
        
        
    }

    public override void AddAttack()
    {
        _distantAttack = gameObject.AddComponent<MultiplyDistantAttack>();
        _distantAttack.projectile = projectile;
        _distantAttack.rotationAngle = rotationAngle;
        _distantAttack.countOfProjectiles = countOfProjectiles;
    }
    
    public override void RemoveAttack()
    {
        Destroy(_distantAttack);
    }
    
    public override void EndPhase()
    {
        _bossController.isStop = false;
        _animator.SetTrigger("BackToIdle");
    }

}
