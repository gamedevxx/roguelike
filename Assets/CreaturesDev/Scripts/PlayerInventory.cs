using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int inventorySize = 10;

    private Dictionary<int, int> _inventory;

    private List<int> _freeInventoryPositions;

    private void Start()
    {
        _inventory = new Dictionary<int, int>();
        _freeInventoryPositions = new List<int>(Enumerable.Range(0, inventorySize));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        ThingTag thing = col.gameObject.GetComponent<ThingTag>();

        if (thing == null)
        {
            return;
        }

        _inventory[_freeInventoryPositions.Last()] = thing.Pickup();
        _freeInventoryPositions.Remove(_freeInventoryPositions.Count - 1);
    }

    public void SetEmptyOn(int id)
    {
        _inventory.Remove(id);
        _freeInventoryPositions.Add(id);
    }

    public bool IsEmptyOn(int id)
    {
        return _inventory.TryGetValue(id, out var value);
    }

    public int GetOn(int id)
    {
        return _inventory[id];
    }
    
    public void SetOn(int id, int thing)
    {
        _inventory[id] = thing;
        _freeInventoryPositions.Remove(id);
    }

    public void Move(int idFrom, int idTo)
    {
        _inventory[idTo] = _inventory[idFrom];
        _inventory.Remove(idFrom);

        _freeInventoryPositions.Remove(idTo);
        _freeInventoryPositions.Add(idFrom);
    }
}
