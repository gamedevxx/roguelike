using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWithEffect : Projectile
{
    public float effectDuration = 10;
    public float effectStrength = 1;
    public CreatureEffectManager.EffectType effectType = CreatureEffectManager.EffectType.Freeze;
    
    protected override void DamageEnemy(GameObject enemy)
    {
        CreatureEffectManager creatureEffectManager = enemy.GetComponent<CreatureEffectManager>();
        if (creatureEffectManager != null)
        {
            creatureEffectManager.AddEffect(
                new CreatureEffectManager.Effect(
                    effectDuration,
                    effectStrength,
                    effectType));
        }
        
        base.DamageEnemy(enemy);
    }
}
