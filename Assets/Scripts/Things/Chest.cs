using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Sprite[] animationSprites; //array of sprites
    public float animationTime = 1.0f; //how often does it circle to the next sprite

    private SpriteRenderer _spriteRenderer;
    private int _spriteIndex;

    public int generatedCount = 1;

    private bool _activated;

    public float delay = 5.0f;

    private ThingsSpawnManager _thingsSpawnManager;
    private Animator _animator;

    private void Start()
    {
        _thingsSpawnManager = FindObjectOfType<ThingsSpawnManager>();
        _animator = GetComponent<Animator>();
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

    IEnumerator Wait(float delay)
    {
        yield return new WaitForSeconds(delay);
        _thingsSpawnManager.AssignToSpawn(transform.position, generatedCount);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger)
        {
            return;
        }
        
        if (collision.CompareTag("Player") && !_activated)
        {
            _activated = true;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
            StartCoroutine(Wait(delay));
        }
    }
}
