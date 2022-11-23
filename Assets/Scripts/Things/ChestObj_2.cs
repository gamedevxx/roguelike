using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestObj_2 : MonoBehaviour
{
    public Sprite[] animationSprites; //array of sprites
    public float animationTime = 1.0f; //how often does it cicle to the next sprite

    private SpriteRenderer _spriteRenderer;
    private int _spriteIndex;

    public float delay = 5.0f;

    private void AnimateSprite()
    {
        _spriteIndex++;
        if (_spriteIndex >= this.animationSprites.Length)
        {
            _spriteIndex = 0;
        }
        _spriteRenderer.sprite = animationSprites[_spriteIndex];
    }

    IEnumerator ShowAndHide(GameObject go, float delay)
    {
        go.SetActive(true);
        yield return new WaitForSeconds(delay);
        go.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
            StartCoroutine(ShowAndHide(gameObject, delay));
            //collision.GetComponent<Player>().experience += 1000;
        }
    }
}
