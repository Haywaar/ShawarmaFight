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
        float delayTime = 0.0f;
        switch (data.AnimationType)
        {
            case ShowAnimationType.Shake:
                targetViewModel.ShakeIcon();
                delayTime = 1.0f;
                break;
            case ShowAnimationType.Appear:
                targetViewModel.AppearIcon();
                delayTime = 0.0f;
                break;
        }

        _tickManager.InvokeWithDelay(onCompleted, delayTime);
    }
}