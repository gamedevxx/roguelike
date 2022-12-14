using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseController : MonoBehaviour
{
    private BasePhase[] _phases;
    private CreatureBody _creatureBody;

    private int _nPhase;
    void Start()
    {
        _phases = GetComponents<BasePhase>();
        _creatureBody = GetComponent<CreatureBody>();
        ChangePhase();
    }
    
    void Update()
    {
        if (_creatureBody.Health <= _creatureBody.maxHealth - (_nPhase + 1) * (_creatureBody.maxHealth/_phases.Length))
        {
            ++_nPhase;
            ChangePhase();
        }
        
    }

    public void ChangePhase()
    {
        if (_nPhase > 0)
        {
            _phases[_nPhase - 1].EndPhase();
            _phases[_nPhase - 1].enabled = false;
        }

        if (_nPhase < _phases.Length)
        {
            _phases[_nPhase].enabled = true;
            _phases[_nPhase].StartPhase();
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
