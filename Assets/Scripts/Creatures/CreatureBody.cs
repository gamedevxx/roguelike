using UnityEngine;

public class CreatureBody : MonoBehaviour
{
    public float armor;
    public float maxHealth = 100;
    public float healthRegenerationSpeed;
    
    public float changeHealthImmunityProbability = 0;

    public float Health { get; private set; }

    private DamageReaction _damageReaction;
    
    private void Start()    
    {
        _damageReaction = GetComponent<DamageReaction>();
        
        Health = maxHealth;
    }

    private void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
            return;
        }
        
        Health = Mathf.Min(maxHealth, Health + healthRegenerationSpeed * Time.deltaTime);
    }

    public void Heal(float healing)
    {
        Damage(-healing);
    }

    public void AddRegenerationSpeed(float regeneration)
    {
        healthRegenerationSpeed += regeneration;
    }

    public void Damage(float damage)
    {
        if (changeHealthImmunityProbability > 0 && Random.value < changeHealthImmunityProbability)
        {
            return;
        }
        
        if (damage <= 0)
        {
            Health -= damage;
            return;
        }

        Health -= damage * (1 - armor);

        if (_damageReaction != null)
        {
            _damageReaction.OnDamage();
        }
    }
}
