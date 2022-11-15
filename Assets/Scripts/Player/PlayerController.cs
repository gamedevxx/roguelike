using UnityEngine;

public class PlayerController : MoveController
{
    protected override void SetMovementDirection()
    {
        moveDirection = Vector3.zero;

        AddDirectionOn(KeyCode.DownArrow, Vector3.down);
        AddDirectionOn(KeyCode.UpArrow, Vector3.up);
        AddDirectionOn(KeyCode.LeftArrow, Vector3.left);
        AddDirectionOn(KeyCode.RightArrow, Vector3.right);
        
        moveDirection.Normalize();
    }
    
    private void AddDirectionOn(KeyCode key, Vector3 direction)
    {
        if (!Input.GetKey(key))
        {
            return;
        }

        moveDirection += direction;
    }
}
