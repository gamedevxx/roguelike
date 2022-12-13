using UnityEngine;

public class PickablePowerUp : AbstractWeapon
{
    public float duration = 5.0f;
    public float effectStrength = 1.0f;
    public CreatureEffectManager.EffectType effectType = CreatureEffectManager.EffectType.Heal;
    
    public override bool Activate(Vector3 direction)
    {
        GetComponentInParent<CreatureEffectManager>()
            .AddEffect(new CreatureEffectManager.Effect(
                duration, 
                effectStrength, 
                effectType));
        return true;
    }
}
