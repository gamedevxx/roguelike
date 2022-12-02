using System;
using UnityEngine;

public class ThingTag : MonoBehaviour
{
    public int id;
    
    public int Pickup()
    {
        Destroy(gameObject);
        return id;
    }
}
