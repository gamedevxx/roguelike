using System;
using UnityEngine;

[CreateAssetMenu(fileName = "health_up", menuName = "PowerUps/Health")]
public class HealthUp : PowerUp
{
    public float healthInc;

    public override void Activate(GameObject target)
    {
        target.GetComponent<Player>().health += healthInc;
    }

    public override void Deactivate(GameObject target) {}
}
