using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : Room {
	public GameObject ladder;

	public void BossDefeated() {
		ladder.SetActive(true);
	}
}
