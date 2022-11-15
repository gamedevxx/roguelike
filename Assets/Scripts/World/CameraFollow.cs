using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float speed;
    
    public Transform followedObject;

    void Update()
    {
        float movement = speed * Time.deltaTime;

        Vector2 toFollowed = followedObject.position - transform.position;

        if (toFollowed.sqrMagnitude < movement * movement)
        {
            transform.position += (Vector3)toFollowed;
        }
        else
        {
            transform.position += (Vector3)(toFollowed.normalized * movement);
        }
    }
}
