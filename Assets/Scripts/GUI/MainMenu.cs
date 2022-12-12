using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("MetaGame"); // ChooseCharacter scene must have id=1
        // you must add it in building settings
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
