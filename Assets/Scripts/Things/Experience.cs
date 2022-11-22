using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    public GameObject exp;

    public Sprite[] animationSprites; //array of sprites
    public float animationTime = 0.2f; //how often does it cicle to the next sprite

    private SpriteRenderer _spriteRenderer;
    private int _spriteIndex;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Start()
    {
        exp.SetActive(true);
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }


    private void AnimateSprite()
    {
        _spriteIndex++;
        if (_spriteIndex >= this.animationSprites.Length)
        {
            _spriteIndex = 0;
        }
        _spriteRenderer.sprite = animationSprites[_spriteIndex];
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
        //collision.gameObject.GetComponent<Player>().experience += 10;
        exp.SetActive(false);
    }
}
