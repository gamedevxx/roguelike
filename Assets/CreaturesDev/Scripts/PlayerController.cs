using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private enum PlayerState { None, Idle, Run }
    
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private PlayerState _previousState = PlayerState.None;
    private PlayerState _currentState = PlayerState.Idle;

    private Vector3 _moveDirection = Vector3.zero;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _currentState = PlayerState.Idle;
        
        _moveDirection = Vector3.zero;
        
        AddDirectionOn(KeyCode.DownArrow, Vector3.down);
        AddDirectionOn(KeyCode.UpArrow, Vector3.up);
        AddDirectionOn(KeyCode.LeftArrow, Vector3.left);
        AddDirectionOn(KeyCode.RightArrow, Vector3.right);

        Move();

        UpdateSprite();
    }

    private void UpdateSprite()
    {
        if (_moveDirection.x != 0)
        _spriteRenderer.flipX = _moveDirection.x < 0;
        ChangeAnimationState();
    }

    private void ChangeAnimationState()
    {
        if (_currentState == _previousState)
        {
            return;
        }
        
        _animator.Play(AnimationByState(_currentState));
        _previousState = _currentState;
    }

    private void AddDirectionOn(KeyCode key, Vector3 direction)
    {
        if (!Input.GetKey(key))
        {
            return;
        }

        _moveDirection += direction;
        _currentState = PlayerState.Run;
    }

    private void Move()
    {
        _moveDirection = _moveDirection.normalized;
        
        _rigidbody.MovePosition(transform.position + speed * Time.deltaTime * _moveDirection);
    }
    
    private static string AnimationByState(PlayerState state)
    {
        return state switch
        {
            PlayerState.Idle => "Player_Idle",
            PlayerState.Run => "Player_Run",
            _ => "Player_Idle"
        };
    }
}
