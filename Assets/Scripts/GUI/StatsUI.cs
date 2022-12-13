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
    public Slider energySlider;
   
    void Update()
    {
        RefillHealthPanel();
        RefillArmorPanel();
        RefillExperiencePanel();
        RefillEnergyPanel();
    }

    private void RefillHealthPanel()
    {
        var maxHealth = playerManager.GetMaxHealth();
        var curHealth = playerManager.GetHealth();
        healthSlider.value = curHealth / maxHealth;
    }

    private void RefillArmorPanel()
    {
        armorSlider.value = playerManager.GetArmor();
    }
    
    private void RefillExperiencePanel()
    {
        var maxExperience = playerManager.GetMaxExperience();
        var curExperience = playerManager.GetExperience();
        experienceSlider.value = curExperience / maxExperience;
    }

    private void RefillEnergyPanel()
    {
        var maxEnergy = playerManager.GetMaxEnergy();
        var curEnergy = playerManager.GetEnergy();
        energySlider.value = curEnergy / maxEnergy;
    }
} 
