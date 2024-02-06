using System.Collections.Generic;
using Zenject;

public class GameStateWin : GameState
{
    [Inject]
    private TurnManager _turnManager;

    public GameStateWin(GameStateType gameStateType) : base(gameStateType)
    {
    }

    public override bool CanSwitchToState(GameStateType gameStateType)
    {
        return false;
    }

    public override void OnEnter()
    {
        var command0 = _turnManager.CreateSetMenuStateCommand(UIPanelStateType.Message);
        var strings = new List<string> { "Молодец!", "Спортик и труд жирок перетрут!","Вы получили опыт, но так как фичи прокачки нет - просто вам почёт и уважение!" };
        var command1 = _turnManager.CreateShowMessageCommand(strings);

        var command2 = _turnManager.CreateLoadSceneCommand(StringConstants.WALKING_SCENE_NAME);
        var commands = new List<Command>(){
            command0,
            command1,
            command2
        };
        _turnManager.ExecuteCommands(commands);
    }
}