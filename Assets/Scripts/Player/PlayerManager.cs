using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private CreatureBody _creatureBody;

    private void Start()
    {
        _creatureBody = GetComponent<CreatureBody>();
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

    /*
    public float GetExperience()
    {

    }

    public float GetMaxExperience()
    {

    }
    */

    // TODO: more functions to interact with player
}
