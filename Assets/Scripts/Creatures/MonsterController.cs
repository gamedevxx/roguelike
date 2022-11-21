using UnityEngine;

public class MonsterController : MoveController
{
    public float viewRange;
    public float minDistance;
    
    private Transform _player;

    protected override void Start()
    {
        base.Start();
        _player = FindObjectOfType<PlayerTag>().transform;
    }

    protected override void SetMovementDirection()
    {
        Vector3 toPlayer = _player.position - transform.position;

        if (InViewRange(toPlayer) && NotTooNear(toPlayer))
        {
            moveDirection = toPlayer.normalized;
        }
        else
        {
            moveDirection = Vector3.zero;
            // move from player, if too near ??
        }
    }

    protected bool InViewRange(Vector3 toObject)
    {
        return toObject.sqrMagnitude < viewRange * viewRange;
    }

    protected bool NotTooNear(Vector3 toObject)
    {
        return toObject.sqrMagnitude > minDistance * minDistance;
    }
}
