using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
    public GameObject DoorU;
    public GameObject DoorD;
    public GameObject DoorL;
    public GameObject DoorR;

    public List<GameObject> roomFinishObjects;
    public List<GameObject> roomOnPlayerEnterObjects;

    public List<float> roomFinishObjectsProbabilities;

    public int Xmin;
    public int Xmax;
    public int Ymin;
    public int Ymax;
    public int minEnemyCnt;
    public int maxEnemyCnt;
    public bool noEnemies = false;

    public List<GameObject> enemies;
    public List<float> enemyProbabilities;

    protected OnDestroyManager enemiesKilled;

    private bool _roomActivated = false;
    
    public void Start()
    {
        if (noEnemies)
        {
            OnRoomFinish();
        }
    }

    private void GenerateEnemies() {
    	int enemyCount = Random.Range(minEnemyCnt, maxEnemyCnt);
        enemiesKilled = new OnDestroyManager(enemyCount);
    	for (int i = 0; i < enemyCount; ++i) 
        {
    		int x = Random.Range(Xmin + 1, Xmax - 1);
    		int y = Random.Range(Ymin + 1, Ymax - 1);
    		Spawn(new Vector2(x, y));
    	}
    }

    private void Spawn(Vector3 position)
    {
        var randomValue = Random.value;

        for (int i = 0; i < enemyProbabilities.Count; ++i)
        {
            randomValue -= enemyProbabilities[i];

            if (randomValue <= 0)
            {
                Instantiate(enemies[i], position + transform.position, Quaternion.identity).GetComponent<MonsterTag>().onDestroyManager = enemiesKilled;
                break;
            }
        }
    }

    public void Update() {
        if (!noEnemies && _roomActivated && enemiesKilled is { alive: 0 }) 
        {
            OnRoomFinish();
        }
    }

    protected virtual void OnRoomFinish()
    {
        ChangeDoorsState(false);
        for (int i = 0; i < roomFinishObjects.Count; ++i)
        {
            if (Random.value <= roomFinishObjectsProbabilities[i])
            {
                roomFinishObjects[i].SetActive(true);
            }
        }

        if (enemiesKilled != null)
        {
            enemiesKilled.alive -= 1;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (!noEnemies
            && !_roomActivated
            && !col.isTrigger 
            && col.gameObject.GetComponent<PlayerTag>() != null 
            && (enemiesKilled is null || enemiesKilled.alive > 0))
        {
            ActivateRoom();
        }
    }

    protected virtual void ActivateRoom()
    {
        foreach(var v in roomOnPlayerEnterObjects)
        {
            v.SetActive(true);
        }
        GenerateEnemies();
        ChangeDoorsState(true);
        _roomActivated = true;
    }

    protected void ChangeDoorsState(bool state) {
        if (DoorR != null) 
        {
            DoorR.SetActive(state);
        }
        if (DoorL != null)
        {
            DoorL.SetActive(state);
        }
        if (DoorD != null) 
        {
            DoorD.SetActive(state);
        }
        if (DoorU != null) 
        {
            DoorU.SetActive(state);
        }
    }
}
