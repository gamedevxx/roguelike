using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnPlace : MonoBehaviour
{
    public float topPosition = 0.1f;
    
    public float bottomPosition = -0.1f;

    public float speed = 0.1f;

    public float minSpeed = 0.03f;
    
    private float _startPosition;
    
    private bool _moveUp = true;

    private bool _firstUpdate = true;

    private void Update()
    {
        if (_firstUpdate)
        {
            _startPosition = transform.position.y;
            _firstUpdate = false;
        }
        
        float currentPosition = transform.position.y - _startPosition;
        
        float coefficient = 
            Mathf.Max(currentPosition >= 0 
                ? ((topPosition - currentPosition) / topPosition) 
                : ((bottomPosition - currentPosition) / bottomPosition), 
            minSpeed);

        float positionChange = speed * Time.deltaTime;

        if (_moveUp)
        {
            if (currentPosition + positionChange >= topPosition)
            {
                transform.position = (_startPosition + topPosition) * Vector3.up;
                _moveUp = false;
            }
            else
            {
                transform.position += positionChange * Vector3.up;
            }
        }
        else
        {
            if (currentPosition - positionChange <= bottomPosition)
            {
                transform.position = (_startPosition + bottomPosition) * Vector3.up;
                _moveUp = true;
            }
            else
            {
                transform.position -= positionChange * Vector3.up;
            }
        }
    }
}
