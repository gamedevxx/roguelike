using System.Collections;
using UnityEngine;

public class DamageReaction : MonoBehaviour
{
    public float timeout = 0.1f;
    public Color damagedColor = Color.red;
        
    private SpriteRenderer _spriteRenderer;
        
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnDamage()
    {
        StartCoroutine(DamageReactionCoroutine());
    }
        
    private IEnumerator DamageReactionCoroutine()
    {
        _spriteRenderer.color = damagedColor;
        yield return new WaitForSeconds(timeout);
        _spriteRenderer.color = Color.white;
    }
}
