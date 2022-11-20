using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction = new Vector3(1, 0, 0);
    public float speed = 5;
    public float damage = 10;

    public String enemyTag = "Player";

    private void Update()
    {
        transform.position += speed * Time.deltaTime * direction;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger) // ??
        {
            return;    
        }
        
        CreatureBody enemyBody = col.gameObject.GetComponent<CreatureBody>();

        if (enemyBody != null && enemyBody.CompareTag(enemyTag))
        {
            enemyBody.Damage(damage);
            Destroy(gameObject);
            return;
        }

        if (col.gameObject.CompareTag("Env"))
        {
            Destroy(gameObject);
        }
    }
}
