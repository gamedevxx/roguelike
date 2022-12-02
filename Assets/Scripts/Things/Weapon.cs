using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : AbstractWeapon
{
    public float damage;

    private List<CreatureBody> _enemyList = new();

    public override void Activate()
    {
        foreach (var enemy in _enemyList) {
            Damage(enemy);
        }
    }

    public virtual void Damage(CreatureBody enemy)
    {
        enemy.Damage(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Enemy"))
        {
            _enemyList.Add(collision.GetComponent<CreatureBody>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            _enemyList.Remove(collision.GetComponent<CreatureBody>());
        }
    }
}
