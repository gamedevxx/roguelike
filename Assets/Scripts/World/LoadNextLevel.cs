using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
	    if (other.isTrigger)
	    {
		    return;
	    }

	    if (other.CompareTag("Player")) {
            int activeId = PlayerPrefs.GetInt("active");
            Save save = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("Save" + activeId));
            save.playerCurrentLevel = PlayerInfo.Level;
            save.playerExperience = PlayerInfo.Experience;
            save.playerFreeLevels = PlayerInfo.AddedLevels;
            PlayerPrefs.SetString("Save" + activeId, JsonUtility.ToJson(save));
            SceneManager.LoadScene("Dungeon");
        }
    }
}
