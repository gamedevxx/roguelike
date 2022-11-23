using UnityEngine;

public class MonsterUpgrader : MonoBehaviour
{
    private CreatureBody _creatureBody;
    private MonsterMeleeAttack _monsterMeleeAttack;
    private MonsterDistantAttack _monsterDistantAttack;

    private void Awake()
    {
        _creatureBody = GetComponent<CreatureBody>();
        _monsterMeleeAttack = GetComponent<MonsterMeleeAttack>();
        _monsterDistantAttack = GetComponent<MonsterDistantAttack>();

        float k = 2 - (1.0f / PlayerInfo.level);

        if (_creatureBody != null)
        {
            _creatureBody.armor *= k;
            _creatureBody.maxHealth *= k;
        }

        if (_monsterMeleeAttack != null)
        {
            _monsterMeleeAttack.damage *= k;
            _monsterMeleeAttack.attackTimeout /= k;
        }

        if (_monsterDistantAttack != null)
        {
            _monsterDistantAttack.timeout /= k;
        }
    }
}
