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

        if (toPlayer.sqrMagnitude < viewRange * viewRange && toPlayer.sqrMagnitude > minDistance * minDistance)
        {
            moveDirection = toPlayer.normalized;
        }
        else
        {
            moveDirection = Vector3.zero;
        }
    }
}
