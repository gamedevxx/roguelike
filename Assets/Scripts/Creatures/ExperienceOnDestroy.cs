using UnityEngine;

public class ExperienceOnDestroy : MonoBehaviour
{
    public int experienceAmount;
    
    private void OnDestroy()
    {
        PlayerInfo.GainExperience(experienceAmount);
    }
}
