using UnityEngine;

public class MonsterTag : MonoBehaviour
{
	public OnDestroyManager onDestroyManager;

	private void OnDestroy() {
		if (onDestroyManager != null) {
			onDestroyManager.IamKilled();
		}
	}
}
