using System.Collections.Generic;

public class EffectApplier
{
    // должен быть таргет
    public void ApplyEffects(List<EffectModel> effects, UnitModel targetUnit)
    {
        foreach (var effect in effects)
        {
            ApplyEffect(effect, targetUnit);
        }
    }

    public void ApplyEffect(EffectModel effect, UnitModel targetUnit)
    {
        switch (effect.EffectType)
        {
            case EffectType.Attack:
                targetUnit.SubstractHealth((int)effect.Value);
                break;
            case EffectType.Heal:
                targetUnit.AddHealth((int)effect.Value);
                break;
        }
    }
}