using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ThingsSpawnManager : MonoBehaviour
{
    public float maxSpawnDistance = 1;
    
    public List<GameObject> things;
    public List<float> thingProbabilities;

    public List<GameObject> potions;
    public List<float> potionProbabilities;
    
    private List<Vector3> _toSpawnThings;
    private List<Vector3> _toSpawnPotions;

    public enum ThingType
    {
        Thing,
        Potion
    }
    
    private void Start()
    {
        _toSpawnThings = new List<Vector3>();
        _toSpawnPotions = new List<Vector3>();
    }

    private void Update()
    {
        SpawnList(_toSpawnThings, ThingType.Thing);
        SpawnList(_toSpawnPotions, ThingType.Potion);
    }
    
    public void AssignToSpawn(Vector3 position, int amount, ThingType thingType)
    {
        for (int i = 0; i < amount; ++i)
        {
            Vector3 instancePosition = position + (Vector3)(maxSpawnDistance * Random.insideUnitCircle);
            switch (thingType)
            {
                case ThingType.Thing:
                    _toSpawnThings.Add(instancePosition);
                    break;
                case ThingType.Potion:
                    _toSpawnPotions.Add(instancePosition);
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }

    private void SpawnList(List<Vector3> toSpawn, ThingType thingType)
    {
        List<GameObject> spawnObjects;
        List<float> spawnObjectsProbabilities;

        switch (thingType)
        {
            case ThingType.Thing:
                spawnObjects = things;
                spawnObjectsProbabilities = thingProbabilities;
                break;
            case ThingType.Potion:
                spawnObjects = potions;
                spawnObjectsProbabilities = potionProbabilities;
                break;
            default:
                throw new IndexOutOfRangeException();
        }
        
        foreach (var position in toSpawn)
        {
            Spawn(position, spawnObjects, spawnObjectsProbabilities);
        }
        toSpawn.Clear();
    }

    private void Spawn(Vector3 position, List<GameObject> spawnObjects, List<float> spawnObjectsProbabilities)
    {
        var randomValue = Random.value;

        for (int i = 0; i < spawnObjectsProbabilities.Count; ++i)
        {
            randomValue -= spawnObjectsProbabilities[i];

            if (randomValue <= 0)
            {
                Instantiate(spawnObjects[i], position, spawnObjects[i].transform.rotation);
                return;
            }
        }
    }
}
