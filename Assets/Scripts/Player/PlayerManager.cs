using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private CreatureBody _creatureBody;
    private PlayerInventory _playerInventory;

    private void Start()
    {
        _creatureBody = GetComponent<CreatureBody>();
        _playerInventory = GetComponent<PlayerInventory>();
    }

    public float GetHealth()
    {
        return _creatureBody.Health;
    }

    public float GetMaxHealth()
    {
        return _creatureBody.maxHealth;
    }

    public float GetArmor()
    {
        return _creatureBody.armor;
    }
    
    // TODO: more functions to interact with player
}
