using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttack : MonoBehaviour
{
    private BossController _bossController;
    private Animator _animator;
    public float damage = 10;
    public float radius = 5;
    public float timeForJump = 5;

    private float _currTime;
    
    private CreatureBody _playerBody;
    private CreatureEffectManager _playerEffectManager;
    
    public float effectDuration = 5;
    public float effectStrength = 2;
    public CreatureEffectManager.EffectType effectType = CreatureEffectManager.EffectType.Freeze;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _bossController = GetComponent<BossController>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _playerBody = player.GetComponent<CreatureBody>();
        _playerEffectManager = player.GetComponent<CreatureEffectManager>();

    }

    
    void Update()
    {
        _currTime += Time.deltaTime;
        if (_currTime >= timeForJump && _bossController.InViewRange())
        {
            _currTime = 0.0f;
            _bossController.isStop = true;
            _animator.SetTrigger("StartJump");
            _animator.SetTrigger("BackToIdle");
            
        }
    }

    public void DamagePlayer()
    {
        if (_bossController.InRadius(radius))
        {
            _playerBody.Damage(damage);
            
            if (_playerEffectManager != null)
            {
                _playerEffectManager.AddEffect(
                    new CreatureEffectManager.Effect(
                        effectDuration,
                        effectStrength,
                        effectType));
            }
        }
    }
}
