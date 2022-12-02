using System.Collections.Generic;
using System.Linq;

public static class PlayerInventory
{
    public const int InventorySize = 10;

    private static List<int> _freeInventoryPositions;
    
    private static Dictionary<int, int> _inventory;

    static PlayerInventory()
    {
        _freeInventoryPositions = new List<int>(Enumerable.Range(0, InventorySize));
        _inventory = new Dictionary<int, int>();
    }

    public static void Put(int thing)
    {
        _inventory[_freeInventoryPositions.Last()] = thing;
        _freeInventoryPositions.Remove(_freeInventoryPositions.Count - 1);
    }
    
    public static void SetEmptyOn(int id)
    {
        _inventory.Remove(id);
        _freeInventoryPositions.Add(id);
    }

    public static bool IsEmptyOn(int id)
    {
        return _inventory.TryGetValue(id, out var value);
    }

    public static int GetOn(int id)
    {
        return _inventory[id];
    }
    
    public static void SetOn(int id, int thing)
    {
        _inventory[id] = thing;
        _freeInventoryPositions.Remove(id);
    }

    public static void Move(int idFrom, int idTo)
    {
        _inventory[idTo] = _inventory[idFrom];
        _inventory.Remove(idFrom);

        _freeInventoryPositions.Remove(idTo);
        _freeInventoryPositions.Add(idFrom);
    }

    public static int ThingsAmount()
    {
        return InventorySize - _freeInventoryPositions.Count;
    }
}