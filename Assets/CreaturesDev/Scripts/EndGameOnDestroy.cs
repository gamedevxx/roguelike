using UnityEngine;

public class EndGameOnDestroy : MonoBehaviour
{
    private void OnDestroy()
    {
        Application.Quit();
    }
}
