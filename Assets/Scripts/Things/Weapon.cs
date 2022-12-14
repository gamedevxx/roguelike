using System.Collections.Generic;
using UnityEngine;

public class Weapon : AbstractWeapon
{
    public float damage;
    
    public float timeout = 1.0f;

    public float offset = 0.5f;

    protected PlayerWeaponEnchanter playerWeaponEnchanter;
    
    private List<CreatureEffectManager> _enemyList;

    private Animator _animator;

    private float _lastActivationTime;

    private Vector3 _lastDirection;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();

        _enemyList = new List<CreatureEffectManager>();

        playerWeaponEnchanter = GetComponentInParent<PlayerWeaponEnchanter>();

        _lastActivationTime = Time.time;
    }

    public override bool Activate(Vector3 direction)
    {
        transform.rotation = Quaternion.FromToRotation(Vector3.down, direction);
        transform.position += direction * offset;
        transform.position -= _lastDirection * offset;
        _lastDirection = direction;
        if (_lastActivationTime + playerWeaponEnchanter.EnchantTimeout(timeout) > Time.time)
        {
            return false;
        }

        foreach (var enemy in _enemyList) {
            
            Damage(enemy, direction);
        }
        
        _animator.Play("Simple");

        _lastActivationTime = Time.time;

        return false;
    }

    public virtual void Damage(CreatureEffectManager enemy, Vector3 direction)
    {
        enemy.GetCreatureBody().Damage(playerWeaponEnchanter.EnchantDamage(damage, true));
        playerWeaponEnchanter.AdditionalEnemyAttack(enemy);
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
