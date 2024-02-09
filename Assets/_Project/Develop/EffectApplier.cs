

public class EffectApplier
{
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