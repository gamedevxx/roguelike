using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "weapon", menuName = "Weapon")]
public class Weapon : AbstractWeapon
{
    public float damage;

    public override void Activate(GameObject target)
    {
        //target.GetComponent<Enemy>().health -= damage;
    }
}
