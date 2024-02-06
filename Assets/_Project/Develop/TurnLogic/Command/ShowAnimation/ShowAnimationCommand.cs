using UnityEngine.Events;
using Zenject;

public class ShowAnimationCommand : Command
{
    private PlayerStatusViewModel _playerStatusViewModel;
    private UnitStatusViewModel _enemyStatusViewModel;
    private TickManager _tickManager;

    [Inject]
    public void Construct(PlayerStatusViewModel playerStatusViewModel, UnitStatusViewModel enemyStatusViewModel, TickManager tickManager)
    {
        _playerStatusViewModel = playerStatusViewModel;
        _enemyStatusViewModel = enemyStatusViewModel;
        _tickManager = tickManager;
    }

    public ShowAnimationCommand(ShowAnimationData data) : base(data)
    {
    }

    public override void Execute(UnityAction onCompleted)
    {
        var data = (ShowAnimationData)_commandData;
        var targetViewModel = data.IsPlayer ? _playerStatusViewModel : _enemyStatusViewModel;
        float delayTime = 1.0f;
        targetViewModel.Animate(data.AnimationType);

        _tickManager.InvokeWithDelay(onCompleted, delayTime);
    }
}