using UnityEngine;

public class ExperienceOnDestroy : MonoBehaviour
{
    public float experienceAmount;
    
    private void OnDestroy()
    {
        PlayerInfo.GainExperience(experienceAmount);
    }
}
