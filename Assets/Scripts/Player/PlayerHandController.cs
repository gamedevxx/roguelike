using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                Destroy(gameObject);    
            }

            if (value != -1)
            {
                handThing = Instantiate(_thingObjectsList.thingObjects[value], gameObject.transform, true);
            }

            _handThingId = value;
        }
    }

    public AbstractWeapon handThing;

    private void Start()
    {
        _thingObjectsList = GetComponent<ThingObjectsList>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && _handThingId != -1)
        {
            handThing.Activate();
        }
    }
}
