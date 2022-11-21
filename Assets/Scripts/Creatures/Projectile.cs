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

        if (col.gameObject.CompareTag(enemyTag))
        {
            DamageEnemy(gameObject);

            Destroy(gameObject);
            return;
        }

        if (col.gameObject.CompareTag("Env"))
        {
            Destroy(gameObject);
        }
    }

    protected virtual void DamageEnemy(GameObject enemy)
    {
        CreatureBody enemyBody = enemy.GetComponent<CreatureBody>();
        if (enemyBody != null)
        {
            enemyBody.Damage(damage);
        }
    }
}
