using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloningPhase : BasePhase
{
    private MonsterMeleeAttack _meleeAttack;
    private MonsterSpawnAttack _spawnAttack;
    private BossController _bossController;
    private Animator _animator;
    
    public GameObject spawnedObject;
    
    public float damage = 10;
    
    void Start()
    {
        enabled = false;
    }
    public override void StartPhase()
    {
        _animator = GetComponent<Animator>();
        
        _bossController = GetComponent<BossController>();
        _bossController.minDistance = 1;
        
        _animator.SetTrigger("BackToIdle");
        
        AddAttack();
        
    }
    
    public override void AddAttack()
    {
        _meleeAttack = gameObject.AddComponent<MonsterMeleeAttack>();
        _meleeAttack.damage = damage;
        
        _spawnAttack = gameObject.AddComponent<MonsterSpawnAttack>();
        _spawnAttack.spawnedObject = spawnedObject;
    }

    public override void RemoveAttack()
    {
        Destroy(_meleeAttack);
        Destroy(_spawnAttack);
    }
    
    public override void EndPhase()
    {
        _animator.SetTrigger("BackToIdle");
        RemoveAttack();
    }
}