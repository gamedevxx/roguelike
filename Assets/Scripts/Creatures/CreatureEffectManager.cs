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
        Damage
    }
    
    public class Effect
    {
        private readonly float _effectStrength;
        private readonly EffectType _effectType;

        public float TimeLast { get; set; }

        public float EffectStrength
        {
            get => _effectStrength;
            set => throw new NotImplementedException();
        }

        public EffectType EffectType
        {
            get => _effectType;
            set => throw new NotImplementedException();
        }

        public Effect(float timeLast, float effectStrength, EffectType effectType)
        {
            this.TimeLast = timeLast;
            this._effectStrength = effectStrength;
            this._effectType = effectType;
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
            float effectTime = Mathf.Min(Time.deltaTime, _effects[i].TimeLast);

            _effects[i].TimeLast -= Time.deltaTime;

            switch (_effects[i].EffectType)
            {
                case EffectType.Freeze:
                    break;
                case EffectType.Damage:
                    _creatureBody.Damage(_effects[i].EffectStrength * effectTime);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
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
                _moveController.speed += effect.EffectStrength;
                break;
            case EffectType.Damage:
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
                _moveController.speed -= effect.EffectStrength;
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
