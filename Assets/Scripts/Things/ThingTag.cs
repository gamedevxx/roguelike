using System;
using UnityEngine;

public class ThingTag : MonoBehaviour
{
    public int id;

    private bool _isDestroyed;
    
    public int Pickup()
    {
        _isDestroyed = true;
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
