using UnityEngine;

public class SpawnThingOnDestroy : MonoBehaviour
{
    public int amount = 1;

    public float probability = 0.3f;
    
    public ThingsSpawnManager thingsSpawnManager;

    private void OnDestroy()
    {
        thingsSpawnManager.AssignToSpawn(
                transform.position,
                Mathf.RoundToInt((Random.value * amount) / (1.0f - probability)));
    }
}
