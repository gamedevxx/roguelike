using System;
using System.Collections.Generic;
using UnityEngine;

public class CreatureEffectManager : MonoBehaviour
{
    private CreatureBody _creatureBody;
    private MoveController _moveController;

    public enum EffectType
    {
        Cold,
        Damage
    }
    
    public class Effect
    {
        public float timeLast;
        public float effectStrength;
        public EffectType effectType;

        public Effect(float timeLast, float effectStrength, EffectType effectType)
        {
            this.timeLast = timeLast;
            this.effectStrength = effectStrength;
            this.effectType = effectType;
        }
    }

    private List<Effect> _effects;
    
    private void Start()
    {
        _creatureBody = GetComponent<CreatureBody>();
        _moveController = GetComponent<MoveController>();

        _effects = new List<Effect>();
    }

    private void Update()
    {
        for (int i = 0; i < _effects.Count;)
        {
            float effectTime = Mathf.Min(Time.deltaTime, _effects[i].timeLast);

            _effects[i].timeLast -= Time.deltaTime;

            switch (_effects[i].effectType)
            {
                case EffectType.Cold:
                    break;
                case EffectType.Damage:
                    _creatureBody.Damage(_effects[i].effectStrength * effectTime);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            if (_effects[i].timeLast <= 0)
            {
                OnEndEffect(_effects[i]);
                _effects.Remove(_effects[i]);
                continue;
            }
            ++i;
        }
        
        
    }

    private void OnStartEffect(Effect effect)
    {
        switch (effect.effectType)
        {
            case EffectType.Cold:
                _moveController.speed += effect.effectStrength;
                break;
            case EffectType.Damage:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    private void OnEndEffect(Effect effect)
    {
        switch (effect.effectType)
        {
            case EffectType.Cold:
                _moveController.speed -= effect.effectStrength;
                break;
            case EffectType.Damage:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void AddEffect(Effect effect)
    {
        OnStartEffect(effect);
        _effects.Add(effect);
    }
}
