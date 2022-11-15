using UnityEngine;

public abstract class AbstractWeapon : MonoBehaviour
{
    public abstract void Activate();
    public abstract bool CanBeActivated();
}
