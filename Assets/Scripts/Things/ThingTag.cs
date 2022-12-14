using UnityEngine;

public class ThingTag : MonoBehaviour
{
    public int id;

    public static float experienceOnPickup = 0;

    private bool _isDestroyed;

    public int Pickup()
    {
        if (_isDestroyed)
        {
            return -1;
        }

        _isDestroyed = true;
        
        PlayerInfo.GainExperience(experienceOnPickup);
        
        return id;
    }

    private void Update()
    {
        if (_isDestroyed)
        {
            Destroy(gameObject);
        }
    }
}
