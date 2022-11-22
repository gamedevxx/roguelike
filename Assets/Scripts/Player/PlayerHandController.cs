using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    private int _leftHandThingId = -1;
    private int _rightHandThingId = -1;

    public int LeftHandThingId
    {
        get => _leftHandThingId;
        set
        {
            // TODO: change thing object
            //_leftHandThingId = value;
            throw new NotImplementedException();
        }
    }

    public int RightHandThingId
    {
        get => _rightHandThingId;
        set
        {
            // TODO: change thing object 
            //_rightHandThingId = value;
            throw new NotImplementedException();
        }
    }

    public AbstractWeapon leftHandThing;
    public AbstractWeapon rightHandThing;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && _leftHandThingId != -1)
        {
            //leftHandThing.Activate();
        }

        if (Input.GetKeyDown(KeyCode.E) && _rightHandThingId != -1)
        {
            //rightHandThing.Activate();
        }
    }
}
