public class ApplyEffectData : CommandData
{
    private EffectModel _effectModel;
    private UnitModel _unitModel;

    public EffectModel EffectModel { get => _effectModel; }
    public UnitModel TargetModel { get => _unitModel; }

    public ApplyEffectData(EffectModel effectModel, UnitModel unitModel)
    {
        _effectModel = effectModel;
        _unitModel = unitModel;
    }
}