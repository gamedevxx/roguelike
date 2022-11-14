using UnityEngine;

public class CreatureBody : MonoBehaviour
{
    public float armor;
    
    public float maxHealth;

    public float healthRegenerationSpeed;

    private float _health;
    
    private void Start()
    {
        _health = maxHealth;
    }

    private void Update()
    {
        _health = Mathf.Min(maxHealth, _health + healthRegenerationSpeed * Time.deltaTime);
    }

    public void Damage(float damage) // different damage types ??
    {
        _health -= damage * (1 - armor);
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
