using UnityEngine;

public class MultiplyDistantAttack : MonoBehaviour
{
    public float timeout = 5;

    public float projectileSpawnDistance = 1;

    public float viewRange = 10;

    public Vector3 spawnOffset;
    
    public Projectile projectile;

    private float _lastAttackTime;
    
    private Transform _player;

    public int countOfProjectiles = 12;

    public float rotationAngle = 30;

    private void Start()
    {
        _player = FindObjectOfType<PlayerTag>().transform;
    }

    private void Update()
    {
        if (_lastAttackTime + timeout > Time.time)
        {
            return;
        }

        if ((_player.position - transform.position).sqrMagnitude > viewRange * viewRange)
        {
            return;
        }

        Vector3 pos = transform.position;
        Vector3 playerPos = _player.position;

        Vector3[] vectors = new Vector3[countOfProjectiles];
        
        Vector3 toPlayer = (playerPos - pos).normalized;
        for (int i = 0; i != vectors.Length; ++i)
        {
            if (i % 2 == 0)
            {
                vectors[i] = Quaternion.Euler(0, 0, rotationAngle * i / 2) * toPlayer;
            }
            else
            {
                vectors[i] = Quaternion.Euler(0, 0, -rotationAngle * (i + 1) / 2) * toPlayer;
            }
        }

        for (int i = 0; i != vectors.Length; ++i)
        {
            Projectile spawnedProjectile = Instantiate(
                projectile, 
                pos + spawnOffset + vectors[i] * projectileSpawnDistance, 
                Quaternion.FromToRotation(Vector3.right, vectors[i]));

            spawnedProjectile.direction = vectors[i].normalized;
            Vector3 scale = spawnedProjectile.transform.localScale;
            spawnedProjectile.transform.localScale = new Vector3(0.5f * scale.x, 
                0.5f * scale.y, 1.0f);
        }


        
        _lastAttackTime = Time.time;
    }
}