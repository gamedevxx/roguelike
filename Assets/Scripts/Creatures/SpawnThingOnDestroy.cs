using UnityEngine;

public class SpawnThingOnDestroy : MonoBehaviour
{
    public int amount = 1;

    public ThingsSpawnManager thingsSpawnManager;

    private void OnDestroy()
    {
        thingsSpawnManager.AssignToSpawn(transform.position, amount);
    }
}
