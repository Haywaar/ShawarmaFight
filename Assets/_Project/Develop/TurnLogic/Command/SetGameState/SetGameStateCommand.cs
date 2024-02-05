using UnityEngine.Events;
using Zenject;

public class SetGameStateCommand : Command
{
    private GameStateController _gameStateController;

    [Inject]
    public void Construct(GameStateController controller)
    {
        _gameStateController = controller;
    }

    public SetGameStateCommand(SetGameStateData data) : base(data)
    {
    }

    public override void Execute(UnityAction onCompleted)
    {
        var setGameStateData = (SetGameStateData)_commandData;
        _gameStateController.SetState(setGameStateData.GameStateType);
        onCompleted?.Invoke();
    }
}