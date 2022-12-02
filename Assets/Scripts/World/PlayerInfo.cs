public static class PlayerInfo
{
    public const int ExpPerLevel = 100;
    
    private static int _level = 1;
    private static int _experience;

    public static int Level
    {
        get => _level;
        private set => _level = value;
    }

    public static int Experience
    {
        get => _experience;
        private set
        {
            _experience = value;
            _level += _experience / ExpPerLevel;
            _experience %= ExpPerLevel;
        }
    }

    public static void GainExperience(int points)
    {
        Experience += points;
    }

    public static void ResetLevel()
    {
        _level = 0;
        _experience = 0;
    }
}