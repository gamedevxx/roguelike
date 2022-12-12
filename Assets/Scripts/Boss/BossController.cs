using UnityEngine;
using System;

public class BossController : MonoBehaviour
{
    public float viewRange;
    public float minDistance;
    public float speed;
    [NonSerialized]
    public float z_rotation = 0f;

    [NonSerialized] public string movementTrigger = "StartRun";
    [NonSerialized] public bool isStop = false;

    public bool lookOnRight = true;
    
    private Transform _player;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Transform _transform;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _transform = GetComponent<Transform>();
        _player = FindObjectOfType<PlayerTag>().transform;
    }
    

    public bool InViewRange()
    {
        Vector3 toPlayer = _player.position - transform.position;
        return toPlayer.sqrMagnitude < viewRange * viewRange;
    }

    public bool NotTooNear()
    {
        Vector3 toPlayer = _player.position - transform.position;
        return toPlayer.sqrMagnitude > minDistance * minDistance;
    }
    
    public bool NotTooNear(Vector3 position)
    {
        Vector3 toPoint = position - transform.position;
        return toPoint.sqrMagnitude > minDistance * minDistance;
    }
    
    public Vector3 PlayerPosition()
    {
        return _player.position;
    }

    public bool MovingCondition()
    {
        return InViewRange() && NotTooNear();
    }

    public void Move()
    {
        _rigidbody.velocity = speed * MovementDirection();
    }
    
    public void Move(Vector3 direction)
    {
        _rigidbody.velocity = speed * direction;
    }
    
    
    public Vector3 MovementDirection()
    {
        Vector3 toPlayer = _player.position - transform.position;
        return toPlayer.normalized;
    }
    
    public Vector3 MovementDirection(Vector3 position)
    {
        Vector3 toPoint = position - transform.position;
        return toPoint.normalized;
    }
    
    public void UpdateSprite()
    {
        Vector3 direction = MovementDirection();
        bool cond = lookOnRight ? (direction.x < 0) : (direction.x > 0);
        if (direction.x != 0)
        {
            float z = cond ? z_rotation : -z_rotation;

            _transform.rotation = Quaternion.Euler(0.0f, 0.0f, z);
            _spriteRenderer.flipX = cond;
        }
    }

    public bool InRadius(float radius)
    {
        Vector3 toPlayer = _player.position - transform.position;
        return toPlayer.sqrMagnitude <= radius * radius;
        
    }
}