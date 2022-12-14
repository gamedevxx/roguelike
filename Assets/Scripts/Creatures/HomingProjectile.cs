using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : ProjectileWithEffect
{
    public float maxlifetime = 5;
    private Transform _player;
    private float lifetime = 0;

    void Start()
    {
        _player = FindObjectOfType<PlayerTag>().transform;
    }
    
    void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime > maxlifetime)
        {
            Destroy(gameObject);
        }
        direction = (_player.position - transform.position).normalized;
        transform.position += speed * Time.deltaTime * direction;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(_player.position.y - transform.position.y, _player.position.x - transform.position.x) * Mathf.Rad2Deg - 180);
    }
}
