using System.Collections;
using UnityEngine;

public class PlayerThingsCollector : MonoBehaviour
{
    public float pickupThingTimeout = 0.5f;
    
    private PlayerHandController _playerHandController;

    private void Start()
    {
        _playerHandController = GetComponent<PlayerHandController>();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        ThingTag thing = col.gameObject.GetComponent<ThingTag>();

        if (thing == null)
        {
            return;
        }

        StartCoroutine(PickupThingCoroutine(thing));
    }

    private IEnumerator PickupThingCoroutine(ThingTag thing)
    {
        yield return new WaitForSeconds(pickupThingTimeout);
        
        if (PlayerInventory.ThingsAmount() == 0 
            && _playerHandController.HandThingId == -1)
        {
            _playerHandController.HandThingId = thing.Pickup();
        }
        else
        {
            PlayerInventory.Put(thing.Pickup());
        }
        
    }
}
