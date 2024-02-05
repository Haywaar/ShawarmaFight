using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class ApplyEffectCommand : Command
{
    private EffectApplier _effectApplier;
    private TickManager _tickManager;

    [Inject]
    private void Construct(EffectApplier effectApplier, TickManager tickManager)
    {
        _effectApplier = effectApplier;
        _tickManager = tickManager;
    }

    public ApplyEffectCommand(ApplyEffectData data) : base(data)
    {
    }

    public override void Execute(UnityAction onCompleted)
    {
        var effectData = (ApplyEffectData)_commandData;
        _effectApplier.ApplyEffect(effectData.EffectModel, effectData.TargetModel);
        _tickManager.InvokeWithDelay(onCompleted, 1.5f);
    }
}