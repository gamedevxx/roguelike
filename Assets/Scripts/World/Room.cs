using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
    public GameObject DoorU;
    public GameObject DoorD;
    public GameObject DoorL;
    public GameObject DoorR;

    public int Xmin = -2;
    public int Xmax = 3;
    public int Ymin = -2;
    public int Ymax = 2;

    public HashSet<Vector2Int> enemyPos = new HashSet<Vector2Int>();

    public void Start() {
    	GenerateEnemies();
    }

    private void GenerateEnemies() {
    	int enemycount = Random.Range(0, 5);
    	for (int i = 0; i < enemycount; ++i) {
    		int x = Random.Range(Xmin, Xmax);
    		int y = Random.Range(Ymin, Ymax);
    		enemyPos.Add(new Vector2Int(x, y));
    	}
    }
}
