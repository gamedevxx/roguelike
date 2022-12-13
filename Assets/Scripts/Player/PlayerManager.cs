using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private CreatureBody _creatureBody;
    private PlayerEnergy _playerEnergy;

    private void Start()
    {
        _creatureBody = GetComponent<CreatureBody>();
        _playerEnergy = GetComponent<PlayerEnergy>();
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
    
    public float GetExperience()
    {
        return PlayerInfo.Experience;
    }

    public float GetMaxExperience()
    {
        return PlayerInfo.ExpPerLevel;
    }

    public float GetEnergy()
    {
        return _playerEnergy.Energy;
    }

    public float GetMaxEnergy()
    {
        return _playerEnergy.maxEnergy;
    }
}
