using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private GameObject _player;
    
    private void Start()
    {
        _player = FindObjectOfType<PlayerTag>().gameObject;
    }

    private void Update()
    {
        
    }
}
