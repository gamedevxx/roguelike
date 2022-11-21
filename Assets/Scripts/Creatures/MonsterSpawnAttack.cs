using UnityEngine;

public class MonsterSpawnAttack : MonoBehaviour
{
    public float spawnZoneSize = 2;

    public float timeout = 6;

    public int minSpawnAmount = 1;

    public int maxSpawnAmount = 3;

    public GameObject spawnedObject;
    
    private Transform _player;

    private float _lastSpawnTime;
    
    void Start()
    {
        _player = FindObjectOfType<PlayerTag>().transform;

        _lastSpawnTime = Time.time;
    }

    void Update()
    {
        if (_lastSpawnTime + timeout > Time.time)
        {
            return;
        }

        int spawnAmount = Mathf.CeilToInt(Random.Range(minSpawnAmount, maxSpawnAmount + 1));

        for (int i = 0; i < spawnAmount; ++i)
        {
            Instantiate(
                spawnedObject,
                transform.position + (Vector3)(spawnZoneSize * Random.insideUnitCircle),
                Quaternion.identity);
        }

        _lastSpawnTime = Time.time;
    }
}
