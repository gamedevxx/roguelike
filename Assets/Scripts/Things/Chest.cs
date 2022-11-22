using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject Chest_obj;

    public Sprite[] animationSprites; //array of sprites
    public float animationTime = 0.5f; //how often does it cicle to the next sprite

    private SpriteRenderer _spriteRenderer;
    private int _spriteIndex;

    public float delay = 2.5f;


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

 
    void Start()
    {
        Chest_obj.SetActive(true);
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
        StartCoroutine(ShowAndHide(Chest_obj, delay));
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

    IEnumerator ShowAndHide(GameObject go, float delay)
    {
        go.SetActive(true);
        yield return new WaitForSeconds(delay);
        go.SetActive(false);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
        Chest_obj.SetActive(false);
        
    }
}
