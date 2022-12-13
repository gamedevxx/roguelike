using UnityEngine;

public static class PlayerInfo
{
    public const int ExpPerLevel = 100;
    
    public static float gainExperienceCoefficient = 1;
    
    private static int _level = 1;
    private static float _experience;

    public static int Level
    {
        get => _level;
        private set => _level = value;
    }

    public static float Experience
    {
        get => _experience;
        private set
        {
            _experience = value;
            int levelsAdded = Mathf.RoundToInt(_experience / ExpPerLevel);
            _level += levelsAdded;
            _experience -= ExpPerLevel * levelsAdded;
        }
    }

    public static void GainExperience(float points)
    {
        Experience += points * gainExperienceCoefficient;
    }

    public static void ResetLevel()
    {
        _level = 0;
        _experience = 0;
    }
}