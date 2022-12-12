using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilitiesApplier : MonoBehaviour
{
    private CreatureBody _creatureBody;
    private MoveController _moveController;

    enum AbilityType
    {
        AdditionalExp, // TODO:  Add GainExperience coefficient
        SpeedUp,
        AdditionalArmor,
        ExperienceFromThings,
        InfinityEnergy, // SPECIAL // ??
        
        Hiding, // SPECIAL // ??
        Regeneration,
        AdditionalHealth, // AdditionalLife ??
        EffectsImmunity,
        MeleeDamageIncrease,
        
        Vampirism,
        DamageIncrease,
        TemporaryBlееding, 
        CriticalDamageProbability,
        AutomaticTargeting, // SPECIAL
        
        DamageTimeoutDecrease,
        IncreasedDropLevel, // ??
        WaterElementalForm, // SPECIAL // ??
        DistantDamageIncrease,
        IncreasedSightRange, // ??
        
        EnemiesSpeedDecreasing,
        DistantDamageInfection,
        FreezingEffect, // ??
        EnemiesCantSpawnEnemies, // SPECIAL
        MeleeDamageInfection,
    }
    
    struct Ability
    {
        public AbilityType type;
        public float strength;
    }

    private void Awake()
    {
        _creatureBody = GetComponent<CreatureBody>();
        _moveController = GetComponent<MoveController>();

        var abilities = GetAbilities();

        foreach (var ability in abilities)
        {
            switch (ability.type)
            {
                default:
                    throw new NotImplementedException();
            }
        }
    }
    
    private List<Ability> GetAbilities()
    {
        throw new NotImplementedException();
    }
}
