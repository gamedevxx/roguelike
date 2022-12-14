using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerThingsCollector : MonoBehaviour
{
    private PlayerHandController _playerHandController;
    private PlayerInventory _playerInventory;

    private void Start()
    {
        _playerHandController = GetComponent<PlayerHandController>();
        _playerInventory = GetComponent<PlayerInventory>();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        ThingTag thing = col.gameObject.GetComponent<ThingTag>();

        if (thing == null)
        {
            return;
        }

        if (_playerInventory.IsFull() && _playerHandController.HandThingId != -1) 
        {
            return;
        }

        _playerInventory.Put(thing.Pickup());
    }
}


