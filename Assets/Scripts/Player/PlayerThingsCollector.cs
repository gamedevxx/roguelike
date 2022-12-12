using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

        _playerInventory.Put(thing.Pickup());      
    }
}
