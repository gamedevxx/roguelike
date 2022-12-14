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
            if (_handThingId != -1 && handThing is not null)
            {
                Destroy(handThing.gameObject);    
            }

            if (value != -1)
            {
                handThing = Instantiate(_thingObjectsList.thingObjects[value], gameObject.transform);
                handThing.transform.position += 0.5f * Vector3.up;
            }
            
            _handThingId = value;
        }
    }

    public AbstractWeapon handThing;

    private void Start()
    {
        _thingObjectsList = GetComponent<ThingObjectsList>();
        PlayerInventory.handController = this;
        HandThingId = -1;
        PlayerInventory.Put(PlayerInventory.handId);
    }
    
    private void Update()
    {
        PlayerInventory.UpdateHand();
        if (HandThingId != -1)
        {
            AttackOnDirection(KeyCode.Q, Vector3.up);
            
            ///////
            
            AttackOnDirection(KeyCode.S, Vector3.down);
            AttackOnDirection(KeyCode.W, Vector3.up);
            AttackOnDirection(KeyCode.A, Vector3.left);
            AttackOnDirection(KeyCode.D, Vector3.right);
        }
    }

    private void AttackOnDirection(KeyCode key, Vector3 direction)
    {
        if (Input.GetKeyDown(key))
        {
            if (handThing.Activate(direction))
            {
                HandThingId = -1;
                
            }
        }
    }
}
