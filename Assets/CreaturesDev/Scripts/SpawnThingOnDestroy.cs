using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThingOnDestroy : MonoBehaviour
{
    public float dropWeight = 1;

    private ThingsSpawnManager _thingsSpawnManager;
    
    private void Start()
    {
        _thingsSpawnManager = FindObjectOfType<ThingsSpawnManager>();
    }

    private void OnDestroy()
    {
        _thingsSpawnManager.Spawn(transform.position, dropWeight);
    }
}
