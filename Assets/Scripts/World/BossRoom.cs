using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : Room {
	public GameObject ladder;

	public List<GameObject> bosses;
    public List<float> bossesProbabilities;

    public new void Start() {
    	base.Start();
    	GenerateBoss();
    }

    public new void Update() {
    	if (enemiesKilled.alive == 0) {
            changeDoorsState(false);
            BossDefeated();
            enemiesKilled.alive -= 1;
        }
    }

    private void GenerateBoss() {
    	enemiesKilled.alive += 1;
    	Vector3 position = new Vector2(Random.Range(Xmin, Xmax), Random.Range(Ymin, Ymax));
    	var randomValue = Random.value;

        for (int i = 0; i < bossesProbabilities.Count; ++i)
        {
            randomValue -= bossesProbabilities[i];

            if (randomValue <= 0)
            {
                Instantiate(bosses[i], position + transform.position, Quaternion.identity).GetComponent<MonsterTag>().onDestroyManager = enemiesKilled;
                break;
            }
        }
    }

	public void BossDefeated() {
		ladder.SetActive(true);
	}
}
