using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public const int InventorySize = 9;

    private int[] inventory;
    private int size;
    private int handThingId = -1;

    private PlayerHandController handController;

    void Start()
    {
        handController = gameObject.GetComponent<PlayerHandController>();
        inventory = new int[InventorySize];
        for (int i = 0; i < InventorySize; i++)
        {
            inventory[i] = -1;
        }
        size = 0;
    }

    public void Put(int thing)
    {
        if (handThingId == -1)
        {
            handThingId = thing;
            handController.HandThingId = thing;
        } else {
            for (int i = 0; i < InventorySize; i++)
            {
                if (inventory[i] == -1)
                {
                    inventory[i] = thing;
                    size++;
                    break;
                }
            }
        }
    }

    public void Swap(int id)
    {
        int thing = inventory[id];
        inventory[id] = handThingId;
        handThingId = thing;
        handController.HandThingId = thing;
    }
    
    public void SetEmptyOn(int id)
    {
        if (inventory[id] != -1)
        {
            size--;
        }
        inventory[id] = -1;
    }

    public void SetEmptyOnHand()
    {
        handThingId = -1;
    }

    public bool IsEmptyOn(int id)
    {
        return inventory[id] == -1;
    }

    public bool IsEmptyOnHand()
    {
        return handThingId == -1;
    }

    public int GetOn(int id)
    {
        return inventory[id];
    }

    public void SetOnHand(int thing)
    {
        handThingId = thing;
    }

    public int GetOnHand()
    {
        return handThingId;
    }

    public void SetOn(int id, int thing)
    {
        if (inventory[id] == -1)
        {
            inventory[id] = thing;
            size++;
        }
        inventory[id] = thing;
    }

    public int ThingsAmount()
    {
        int c = 0;
        if (!IsEmptyOnHand())
        {
            c = 1;
        }
        return InventorySize - size - c;
    }
}