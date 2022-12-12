using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameOnDestroy : MonoBehaviour
{
    private void OnDestroy()
    {
        // save stats
        // if hp <= 0 -> meta game
        // else -> next level + save stats
        SceneManager.LoadScene("MetaGame");
        Application.Quit();
    }
}
