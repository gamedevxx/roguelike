using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public const int InventorySize = 9;

    private int[] inventory;
    private int size;

    private int lastHandId = -1;
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

    void Update()
    {
        if (lastHandId != -1 && handController.HandThingId == -1) {
            SwapWithLast();
        }
    }

    public void Put(int thing)
    {
        if (handController.HandThingId == -1)
        {
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
        if (handController.HandThingId != -1) {
            lastHandId = id;
            size++;
        }
        else {
            lastHandId = -1;
        }
        if (inventory[id] != -1) {
            size--;
        }
        (inventory[id], handController.HandThingId) = (handController.HandThingId, inventory[id]);
    }

    public void SwapWithLast()
    {
        if (lastHandId == -1)
        {
            return;
        }
        Swap(lastHandId);
        lastHandId = -1;
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
        handController.HandThingId = -1;
    }

    public bool IsEmptyOn(int id)
    {
        return inventory[id] == -1;
    }

    public bool IsEmptyOnHand()
    {
        return handController.HandThingId == -1;
    }

    public int GetOn(int id)
    {
        return inventory[id];
    }

    public void SetOnHand(int thing)
    {
        handController.HandThingId = thing;
    }

    public int GetOnHand()
    {
        return handController.HandThingId;
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

    public bool IsFull()
    {
        return size == InventorySize;
    }
}