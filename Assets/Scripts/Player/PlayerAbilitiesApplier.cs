using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerAbilitiesApplier : MonoBehaviour
{
    enum AbilityType
    {
        AdditionalExp, // TODO:  Add GainExperience coefficient
        SpeedUp,
        AdditionalArmor,
        ExperienceFromThings,
        FreeEnergyAbilityActivation, // SPECIAL // ??
        
        TemporaryPlayerArmor, // SPECIAL // ??
        Regeneration,
        AdditionalHealth, // AdditionalLife ??
        EffectsImmunity,
        MeleeDamageIncrease,
        
        Vampirism,
        DamageIncrease,
        TemporaryBlееding, 
        CriticalDamageProbability,
        CriticalDamageCoefficientIncrease, // SPECIAL
        
        DamageTimeoutDecrease,
        ChangeHealthImmunityProbability, // ??
        EffectImmunityProbability, // SPECIAL // ??
        DistantDamageIncrease,
        IncreasedSightRange, // ??
        
        MakeEnemiesSlower,
        EnemyArmorDecrease,
        EnemiesCompleteFreezing, // ??
        EnemiesCantSpawnEnemies, // SPECIAL
        DamageInfection,
    }
    
    private CreatureBody _creatureBody;
    private CreatureEffectManager _creatureEffectManager;
    private MoveController _moveController;
    private PlayerEnergy _playerEnergy;
    private PlayerWeaponEnchanter _playerWeaponEnchanter;
    private Light2D _light2D;

    struct Ability
    {
        public AbilityType type;
        public float strength;
    }

    private void Awake()
    {
        _creatureBody = GetComponent<CreatureBody>();
        _creatureEffectManager = GetComponent<CreatureEffectManager>();
        _moveController = GetComponent<MoveController>();
        _playerEnergy = GetComponent<PlayerEnergy>();
        _playerWeaponEnchanter = GetComponent<PlayerWeaponEnchanter>();
        _light2D = GetComponent<Light2D>();

        var abilities = GetAbilities();

        foreach (var ability in abilities)
        {
            switch (ability.type)
            {
                ///////
                
                case AbilityType.AdditionalExp:
                    PlayerInfo.gainExperienceCoefficient *= 1.2f;
                    break;
                case AbilityType.SpeedUp:
                    _moveController.speed *= 1.05f;
                    break;
                case AbilityType.AdditionalArmor:
                    _creatureBody.armor += 0.05f;
                    break;
                case AbilityType.ExperienceFromThings:
                    ThingTag.experienceOnPickup += 5;
                    break;
                case AbilityType.FreeEnergyAbilityActivation:
                    _playerEnergy.energyToActivate = 0;
                    break;
                
                ///////
    
                case AbilityType.TemporaryPlayerArmor:
                    _creatureEffectManager.AddEffect(
                        new CreatureEffectManager.Effect(
                                120,
                                0.3f,
                                CreatureEffectManager.EffectType.Armor
                            ));
                    break;
                case AbilityType.Regeneration:
                    _creatureBody.healthRegenerationSpeed += 0.05f;
                    break;
                case AbilityType.AdditionalHealth:
                    _creatureBody.maxHealth *= 1.2f;
                    break;
                case AbilityType.EffectsImmunity:
                    _creatureEffectManager.effectsCanBeApplied = false;
                    break;
                case AbilityType.MeleeDamageIncrease:
                    _playerWeaponEnchanter.additionalMeleeDamage += 1.2f;
                    break;
    
                ///////
                
                case AbilityType.Vampirism:
                    _playerWeaponEnchanter.vampirismCoefficient += 0.1f;
                    break;
                case AbilityType.DamageIncrease:
                    _playerWeaponEnchanter.additionalMeleeDamage += 0.7f;
                    _playerWeaponEnchanter.additionalDistantDamage += 0.7f;
                    break;
                case AbilityType.TemporaryBlееding:
                    _playerWeaponEnchanter.addedEffects.Add(
                        new CreatureEffectManager.Effect(
                                5,
                                1,
                                CreatureEffectManager.EffectType.Damage
                            ));
                    break;
                case AbilityType.CriticalDamageProbability:
                    _playerWeaponEnchanter.criticalDamageProbability += 0.05f;
                    break;
                case AbilityType.CriticalDamageCoefficientIncrease:
                    _playerWeaponEnchanter.criticalDamageCoefficient *= 1.5f;
                    break;
                
                ///////
                    
                case AbilityType.DamageTimeoutDecrease:
                    _playerWeaponEnchanter.timeoutCoefficient *= 0.9f;
                    break;
                case AbilityType.ChangeHealthImmunityProbability: // ??
                    _creatureBody.changeHealthImmunityProbability = 0.1f;
                    break;
                case AbilityType.EffectImmunityProbability: // ??
                    _creatureEffectManager.immunityProbability += 0.25f;
                    break;
                case AbilityType.DistantDamageIncrease:
                    _playerWeaponEnchanter.additionalDistantDamage += 1.2f;
                    break;
                case AbilityType.IncreasedSightRange:
                    _light2D.pointLightInnerRadius *= 1.1f;
                    _light2D.pointLightOuterRadius *= 1.1f;
                    break;
    
                case AbilityType.MakeEnemiesSlower:
                    _playerWeaponEnchanter.addedEffects.Add(
                        new CreatureEffectManager.Effect(
                                8,
                                1,
                                CreatureEffectManager.EffectType.Freeze
                            ));
                    break;
                case AbilityType.EnemyArmorDecrease:
                    _playerWeaponEnchanter.addedEffects.Add(
                        new CreatureEffectManager.Effect(
                                3,
                                -0.05f,
                                CreatureEffectManager.EffectType.Armor
                            ));
                    break;
                case AbilityType.EnemiesCompleteFreezing:
                    _playerWeaponEnchanter.addedEffects.Add(
                        new CreatureEffectManager.Effect(
                                1.5f,
                                20,
                                CreatureEffectManager.EffectType.Freeze
                            ));
                    break;
                case AbilityType.EnemiesCantSpawnEnemies:
                    MonsterSpawnAttack.usable = false;
                    break;
                case AbilityType.DamageInfection:
                    _playerWeaponEnchanter.addedEffects.Add(
                        new CreatureEffectManager.Effect(
                            120,
                            0.2f,
                            CreatureEffectManager.EffectType.Damage
                        ));
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
    
    private List<Ability> GetAbilities()
    {
        throw new NotImplementedException();
    }
}
