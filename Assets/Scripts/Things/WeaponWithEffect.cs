using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWithEffect : Weapon
{
    public float effectDuration = 5.0f;
    public float effectStrength = 1.0f;
    public CreatureEffectManager.EffectType effectType = CreatureEffectManager.EffectType.Damage;

    public override void Damage(CreatureEffectManager enemy, Vector2 direction)
    {
        CreatureEffectManager.Effect effect =
            new CreatureEffectManager.Effect(effectDuration, effectStrength, effectType);
        
        enemy.AddEffect(playerWeaponEnchanter.EnchantEffect(effect));
        base.Damage(enemy, direction);
    }
}
