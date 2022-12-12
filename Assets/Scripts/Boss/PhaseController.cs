using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseController : MonoBehaviour
{
    private BasePhase[] _phases;

    private float time = 10f;
    private float curr_time = 0f;

    private int n_phase = -1;
    void Start()
    {
        _phases = GetComponents<BasePhase>();
        ChangePhase();
    }
    
    void Update()
    {
        curr_time += Time.deltaTime;
        if (curr_time > 20)
        {
            curr_time = 0;

            ChangePhase();
        }
    }

    public void ChangePhase()
    {
        ++n_phase;
        
        if (n_phase > 0)
        {
            _phases[n_phase - 1].EndPhase();
            _phases[n_phase - 1].enabled = false;
        }

        if (n_phase < _phases.Length)
        {
            _phases[n_phase].enabled = true;
            _phases[n_phase].StartPhase();
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
