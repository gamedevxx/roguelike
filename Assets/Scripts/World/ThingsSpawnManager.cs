using System.Collections.Generic;
using UnityEngine;

public class ThingsSpawnManager : MonoBehaviour
{
    public float maxSpawnDistance = 1;
    
    public List<GameObject> things;
    public List<float> thingProbabilities;

    private List<Vector3> _toSpawn;
    
    private void Start()
    {
        _toSpawn = new List<Vector3>();
    }

    private void Update()
    {
        foreach (var position in _toSpawn)
        {
            Spawn(position);
        }
        
        _toSpawn.Clear();
    }

    public void AssignToSpawn(Vector3 position, int amount)
    {
        for (int i = 0; i < amount; ++i)
        {
            _toSpawn.Add(position + (Vector3)(maxSpawnDistance * Random.insideUnitCircle));
        }
    }

    private void Spawn(Vector3 position)
    {
        var randomValue = Random.value;

        for (int i = 0; i < thingProbabilities.Count; ++i)
        {
            randomValue -= thingProbabilities[i];

            if (randomValue <= 0)
            {
                Instantiate(things[i], position, Quaternion.identity);
            }
        }
    }
}
