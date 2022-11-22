using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
    public GameObject DoorU;
    public GameObject DoorD;
    public GameObject DoorL;
    public GameObject DoorR;

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

    public void Start() {
        if (!noEnemies)
    	   GenerateEnemies();
    }

    private void GenerateEnemies() {
    	int enemycount = Random.Range(minEnemyCnt, maxEnemyCnt);
        enemiesKilled = new OnDestroyManager(enemycount);
    	for (int i = 0; i < enemycount; ++i) {
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
        if (!noEnemies && enemiesKilled.alive == 0) {
            changeDoorsState(false);
            enemiesKilled.alive -= 1;
        }
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if (!noEnemies && !col.isTrigger && col.gameObject.GetComponent<PlayerTag>() != null && enemiesKilled.alive > 0) {
            changeDoorsState(true);
        }
    }

    protected void changeDoorsState(bool state) {
        if (DoorR != null) {
                DoorR.SetActive(state);
            }
            if (DoorL != null) {
                DoorL.SetActive(state);
            }
            if (DoorD != null) {
                DoorD.SetActive(state);
            }
            if (DoorU != null) {
                DoorU.SetActive(state);
            }
    }
}
