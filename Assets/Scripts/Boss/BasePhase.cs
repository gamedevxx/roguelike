using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePhase : MonoBehaviour
{
    public abstract void StartPhase();

    public abstract void AddAttack();
    
    public abstract void RemoveAttack();
    public abstract void EndPhase();

}
