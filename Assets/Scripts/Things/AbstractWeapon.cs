using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractWeapon : MonoBehaviour
{
    public virtual bool Activate(Vector3 direction)
    {
        return false; 
    }
}
