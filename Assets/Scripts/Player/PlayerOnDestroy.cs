using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOnDestroy : MonoBehaviour
{
    private CreatureBody _creatureBody;
    
    private void Start()
    {
        _creatureBody = GetComponent<CreatureBody>();
    }

    private void OnDestroy()
    {
        if (_creatureBody.Health <= 0)
        {
            Debug.Log("Dead");
            // save stats
            // if hp <= 0 -> meta game
            // else -> next level + save stats
            Save save = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("active"));
            save.playerCurrentLevel = PlayerInfo.Level;
            save.playerExperience = PlayerInfo.Experience;
            save.playerFreeLevels = PlayerInfo.AddedLevels;
            PlayerPrefs.SetString("" + save.saveId, JsonUtility.ToJson(save));
            PlayerPrefs.SetInt("active", save.saveId);
            SceneManager.LoadScene("MetaGame");
        }
    }
}
