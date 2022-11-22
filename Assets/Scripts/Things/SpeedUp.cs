using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "speed_up", menuName = "PowerUps/Speed")]
public class SpeedUp : PowerUp
{
    public float speeder;

    public override void Activate(GameObject target)
    {
        target.GetComponent<Player>().speed += speeder;
    }

    public override void Deactivate(GameObject target)
    {
        target.GetComponent<Player>().speed -= speeder;
    }
}