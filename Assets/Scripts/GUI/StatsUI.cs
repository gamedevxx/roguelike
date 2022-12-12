using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public PlayerManager playerManager;
    public Slider armorSlider;
    public Slider healthSlider;
    public Slider experienceSlider;
   
    void Update()
    {
        RefillHealthPanel();
        RefillArmorPanel();
        // RefillExperiencePanel();
    }

    private void RefillHealthPanel()
    {
        var maxHealth = playerManager.GetMaxHealth();
        var curHealth = playerManager.GetHealth();
        healthSlider.value = (float)curHealth / (float)maxHealth;
    }

    private void RefillArmorPanel()
    {
        armorSlider.value = playerManager.GetArmor();
    }

    /*
    private void RefillExperiencePanel()
    {
        var maxExperience = playerManager.GetMaxExperience();
        var curExperience = playerManager.GetExperience();
        experienceSlider.value = (float)curExperience / (float)maxExperience;
    }
    */
} 
