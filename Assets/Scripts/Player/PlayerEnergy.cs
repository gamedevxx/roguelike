using Unity.VisualScripting;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    public float maxEnergy = 10;
    public float energyToActivate = 1;
    public float energyPerSecond = 3;
    public float energyRegenerationPerSecond = 1;

    public float speedUp = 6;

    private MoveController _moveController;

    private bool _activated;

    private bool Activated
    {
        get => _activated;
        set
        {
            if (_activated != value)
            {
                _moveController.speed += (value ? 1 : -1) * speedUp;
            }
            _activated = value;
        }
    }

    public float Energy { get; private set; }

    void Start()
    {
        _moveController = GetComponent<MoveController>();

        Energy = maxEnergy;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!Activated)
            {
                if (Energy < energyToActivate)
                {
                    return;
                }

                Energy -= energyToActivate;
            }

            Activated = !Activated;
        }

        if (Activated)
        {
            if (Energy >= Time.deltaTime * energyPerSecond)
            {
                Energy -= Time.deltaTime * energyPerSecond;
            }
            else
            {
                Activated = false;
            }
        }
        else
        {
            Energy = Mathf.Min(
                Energy + Time.deltaTime * energyRegenerationPerSecond, maxEnergy);
        }
    }
}
