using System.Collections.Generic;
using System.Linq;

public static class PlayerInventory
{
    public const int InventorySize = 9;

    private static int[] inventory;
    private static int size;

    private static int lastHandId = -1;
    public static PlayerHandController handController;

    static PlayerInventory()
    {
    
        inventory = new int[InventorySize];
        for (int i = 0; i < InventorySize; i++)
        {
            inventory[i] = -1;
        }
        size = 0;
    }

    public static void UpdateHand()
    {
        if (lastHandId != -1 && handController.HandThingId == -1) {
            SwapWithLast();
        }
    }

    public static void Put(int thing)
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

    public static void Swap(int id)
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

    public static void SwapWithLast()
    {
        if (lastHandId == -1)
        {
            return;
        }
        Swap(lastHandId);
        lastHandId = -1;
    }
    
    public static void SetEmptyOn(int id)
    {
        if (inventory[id] != -1)
        {
            size--;
        }
        inventory[id] = -1;
    }

    public static void SetEmptyOnHand()
    {
        handController.HandThingId = -1;
    }

    public static bool IsEmptyOn(int id)
    {
        return inventory[id] == -1;
    }

    public static bool IsEmptyOnHand()
    {
        return handController.HandThingId == -1;
    }

    public static int GetOn(int id)
    {
        return inventory[id];
    }

    public static void SetOnHand(int thing)
    {
        handController.HandThingId = thing;
    }

    public static int GetOnHand()
    {
        return handController.HandThingId;
    }

    public static void SetOn(int id, int thing)
    {
        if (inventory[id] == -1)
        {
            inventory[id] = thing;
            size++;
        }
        inventory[id] = thing;
    }

    public static int ThingsAmount()
    {
        int c = 0;
        if (!IsEmptyOnHand())
        {
            c = 1;
        }
        return InventorySize - size - c;
    }

    public static bool IsFull()
    {
        return size == InventorySize;
    }
}