using UnityEngine;

public class CreatureBody : MonoBehaviour
{
    public float armor;
    
    public float maxHealth = 100;

    public float healthRegenerationSpeed;

    public float Health { get; private set; }

    private DamageReaction _damageReaction;
    private CreatureEffectManager _effectManager;
    
    private void Start()    
    {
        _damageReaction = GetComponent<DamageReaction>();
        _effectManager = GetComponent<CreatureEffectManager>();
        
        Health = maxHealth;
    }

    private void Update()
    {
        Health = Mathf.Min(maxHealth, Health + healthRegenerationSpeed * Time.deltaTime);
    }

    public void Damage(float damage) // different damage types ??
    {
        Health -= damage * (1 - armor);
        if (Health <= 0)
        {
            Destroy(gameObject);
        }

        if (_damageReaction != null)
        {
            _damageReaction.OnDamage();
        }
    }

    public CreatureEffectManager GetEffectManager()
    {
        return _effectManager;
    }
}
