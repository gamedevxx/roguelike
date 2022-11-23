using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "weapon", menuName = "Weapon")]
public class Weapon : AbstractWeapon
{
    public float damage;

    List<GameObject> EnemyList = new List<GameObject>();
    //public Enemy[] Temporary;

    public override void Activate()
    {
        //Temporary = FindObjectsOfType<Enemy>();
        /*for (int i = 0; i < Temporary.Length; i++) // Finding all Enemy objects and adding them to list
        {
            EnemyList.Add(Temporary[i].gameObject);
        }*/
    }

    public override void Deactivate()
    {
        for (int i = 0; i < EnemyList.Count; i++)
        {
            //EnemyList[i].GetComponent<Enemy>().health -= damage;

            EnemyList.RemoveAt(i);
        }
    }
}
