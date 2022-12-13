using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class PlayerHandController : MonoBehaviour
{
    private int _handThingId = -1;

    private ThingObjectsList _thingObjectsList;
    
    public int HandThingId
    {
        get => _handThingId;
        set
        {
            if (_handThingId != -1)
            {
                Destroy(handThing.gameObject);    
            }

            if (value != -1)
            {
                handThing = Instantiate(_thingObjectsList.thingObjects[value], gameObject.transform);
                _handThingId = value;
            }
        }
    }

    public AbstractWeapon handThing;

    private void Start()
    {
        _thingObjectsList = GetComponent<ThingObjectsList>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && HandThingId != -1)
        {
            if (handThing.Activate(Vector2.up))
            {
                HandThingId = -1;
            }
        }
    }
}
