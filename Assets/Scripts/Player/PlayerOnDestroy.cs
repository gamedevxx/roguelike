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
            // save stats
            // if hp <= 0 -> meta game
            // else -> next level + save stats
            Camera.main.transform.SetParent(null);
            int activeId = PlayerPrefs.GetInt("active");
            Save save = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("Save" + activeId));
            save.playerCurrentLevel = PlayerInfo.Level;
            save.playerExperience = PlayerInfo.Experience;
            save.playerFreeLevels = PlayerInfo.AddedLevels;
            PlayerPrefs.SetString("Save" + activeId, JsonUtility.ToJson(save));
            SceneManager.LoadScene("MetaGame");
        }
    }
}
