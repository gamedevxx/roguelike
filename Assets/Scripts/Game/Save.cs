using System;

[Serializable]
public class Save
{
    public int saveId; // 0 1 2
    public string playerName;
    public string playerMaxHealth;
    public float playerArmor;
    public int playerFreeLevels;
    public int playerCurrentLevel;
    public int[] playerAbilities;
}