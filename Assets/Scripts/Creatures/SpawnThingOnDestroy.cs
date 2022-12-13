using UnityEngine;

public class SpawnThingOnDestroy : MonoBehaviour
{
    public int amount = 1;

    public float probability = 0.3f;

    public ThingsSpawnManager.ThingType thingType = ThingsSpawnManager.ThingType.Potion;
    
    private ThingsSpawnManager _thingsSpawnManager;

    private void Start()
    {
        _thingsSpawnManager = FindObjectOfType<ThingsSpawnManager>();
    }
    
    private void OnDestroy()
    {
        _thingsSpawnManager.AssignToSpawn(
                transform.position,
                Mathf.RoundToInt((Random.value * amount) / (1.0f - probability)), thingType);
    }
}
