using UnityEngine;

public class MonsterMeleeAttack : MonoBehaviour
{
    public float damage = 10;
    public float attackTimeout = 1;
    
    private float _lastAttackTime;

    private void Start()
    {
        _lastAttackTime = Time.time - attackTimeout;
    }
    
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.isTrigger)
        {
            return;
        }
        
        if (_lastAttackTime + attackTimeout > Time.time)
        {
            return;
        }
        
        PlayerTag player = col.gameObject.GetComponent<PlayerTag>();

        if (player == null)
        {
            return;
        }

        CreatureBody playerBody = player.GetComponent<CreatureBody>();
        
        playerBody.Damage(damage);

        _lastAttackTime = Time.time;
    }
}
