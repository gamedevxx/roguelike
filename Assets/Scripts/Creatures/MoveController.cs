using UnityEngine;

public abstract class MoveController : MonoBehaviour
{
    public float speed;

    private enum MoveState
    {
        None,
        Idle,
        Run
    }

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private MoveState _previousState = MoveState.None;
    private MoveState _currentState = MoveState.Idle;

    protected Vector3 moveDirection = Vector3.zero;

    protected virtual void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update()
    {
        SetMovementDirection();

        UpdateCurrentState();
        Move();
        UpdateSprite();
        UpdateLastState();
    }

    protected abstract void SetMovementDirection();

    private void UpdateCurrentState()
    {
        _currentState = moveDirection == Vector3.zero ? MoveState.Idle : MoveState.Run;
    }

    private void UpdateLastState()
    {
        _previousState = _currentState;
    }

    private void UpdateSprite()
    {
        if (moveDirection.x != 0)
        {
            _spriteRenderer.flipX = moveDirection.x < 0;
        }

        ChangeAnimationState();
    }

    private void ChangeAnimationState()
    {
        if (_currentState == _previousState)
        {
            return;
        }
        
        _animator.Play(AnimationByState(_currentState));
    }

    private void Move()
    {
        _rigidbody.velocity = speed * moveDirection;
    }
    
    private static string AnimationByState(MoveState state)
    {
        return state switch
        {
            MoveState.Idle => "Idle",
            MoveState.Run => "Run",
            _ => "Idle"
        };
    }
}
