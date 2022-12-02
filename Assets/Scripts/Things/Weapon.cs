using System;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : AbstractWeapon
{
    public float damage;
    
    public float timeout = 1.0f;

    private List<CreatureEffectManager> _enemyList;

    private Animator _animator;

    private float lastActivationTime;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();

        _enemyList = new List<CreatureEffectManager>();

        lastActivationTime = Time.time;
    }

    public override bool Activate(Vector2 direction)
    {
        if (lastActivationTime + timeout > Time.time)
        {
            return false;
        }

        foreach (var enemy in _enemyList) {
            
            Damage(enemy, direction);
        }
        
        _animator.Play("Simple");

        lastActivationTime = Time.time;

        return false;
    }

    public virtual void Damage(CreatureEffectManager enemy, Vector2 direction)
    {
        enemy.GetCreatureBody().Damage(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger)
        {
            return;
        }
        
        if (collision.CompareTag("Enemy"))
        {
            _enemyList.Add(collision.GetComponent<CreatureEffectManager>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger)
        {
            return;
        }
        
        if (collision.CompareTag("Enemy"))
        {
            _enemyList.Remove(collision.GetComponent<CreatureEffectManager>());
        }
    }
}
