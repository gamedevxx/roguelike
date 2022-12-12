using System;
using System.Collections.Generic;
using UnityEngine;

public class CreatureEffectManager : MonoBehaviour
{
    private CreatureBody _creatureBody;
    private MoveController _moveController;

    public enum EffectType
    {
        Freeze,
        Damage,
        Heal,
        Regeneration
    }
    
    public class Effect
    {
        private float _effectStrength;
        private EffectType _effectType;

        public float TimeLast { get; set; }

        public float EffectStrength
        {
            get => _effectStrength;
            set => _effectStrength = value;
        }

        public EffectType EffectType
        {
            get => _effectType;
            set => _effectType = value;
        }

        public Effect(float duration, float effectStrength, EffectType effectType)
        {
            TimeLast = duration;
            _effectStrength = effectStrength;
            _effectType = effectType;
        }
    }

    private List<Effect> _effects = new();
    
    private void Start()
    {
        _creatureBody = GetComponent<CreatureBody>();
        _moveController = GetComponent<MoveController>();
    }

    private void Update()
    {
        for (int i = 0; i < _effects.Count;)
        {
            float effectTime = Mathf.Min(Time.deltaTime, _effects[i].TimeLast);

            _effects[i].TimeLast -= Time.deltaTime;

            OnUpdateEffect(_effects[i], effectTime);
            
            if (_effects[i].TimeLast <= 0)
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
        switch (effect.EffectType)
        {
            case EffectType.Freeze:
                _moveController.speed -= effect.EffectStrength;
                break;
            case EffectType.Damage:
                break;
            case EffectType.Heal:
                break;
            case EffectType.Regeneration:
                _creatureBody.Regenerate(effect.EffectStrength);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void OnUpdateEffect(Effect effect, float deltaTime)
    {
        switch (effect.EffectType)
        {
            case EffectType.Freeze:
                break;
            case EffectType.Damage:
                _creatureBody.Damage(effect.EffectStrength * deltaTime);
                break;
            case EffectType.Heal:
                _creatureBody.Heal(effect.EffectStrength * deltaTime);
                break;
            case EffectType.Regeneration:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    private void OnEndEffect(Effect effect)
    {
        switch (effect.EffectType)
        {
            case EffectType.Freeze:
                _moveController.speed += effect.EffectStrength;
                break;
            case EffectType.Damage:
                break;
            case EffectType.Heal:
                break;
            case EffectType.Regeneration:
                _creatureBody.Regenerate(-effect.EffectStrength);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public CreatureBody GetCreatureBody()
    {
        return _creatureBody;
    }

    public void AddEffect(Effect effect)
    {
        OnStartEffect(effect);
        _effects.Add(effect);
    }
}
