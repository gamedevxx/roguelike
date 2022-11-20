using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDistantAttack : MonoBehaviour
{
    public float timeout = 5;

    public float projectileSpawnDistance = 1;

    public Projectile projectile;

    private float _lastAttackTime;
    
    private Transform _player;

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

        Vector3 pos = transform.position;
        Vector3 playerPos = _player.position;

        Vector3 toPlayer = (playerPos - pos).normalized;

        Projectile spawnedProjectile = Instantiate(projectile, pos + toPlayer * projectileSpawnDistance, Quaternion.FromToRotation(Vector3.right, playerPos - pos));

        spawnedProjectile.direction = toPlayer.normalized;
        
        _lastAttackTime = Time.time;
    }
}
