using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpObj : MonoBehaviour
{
    public PowerUp effect;
    public Smoke visualEffect;
    public float duration = 20.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            visualEffect.Blow();
            PowerUpTimer(effect, collision.gameObject, duration);
            gameObject.SetActive(false);
            
        }

    }

    IEnumerator PowerUpTimer(PowerUp effect, GameObject go, float duration)
    {
        effect.Activate(go);
        yield return new WaitForSeconds(duration);
        effect.Deactivate(go);
    }
}
