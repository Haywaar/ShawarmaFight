using System.Collections.Generic;
using Zenject;

public class GameStateLose : GameState
{

    [Inject]
    private TurnManager _turnManager;


    public GameStateLose(GameStateType gameStateType) : base(gameStateType)
    {
    }

    public override bool CanSwitchToState(GameStateType gameStateType)
    {
        return false;
    }

    public override void OnEnter()
    {
        var command0 = _turnManager.CreateSetMenuStateCommand(UIPanelStateType.Message);
        var strings = new List<string> { "Ну ты и жирдяй!", "Тебя победил жалкий кусок еды!" };
        var command1 = _turnManager.CreateShowMessageCommand(strings);
        var commands = new List<Command>(){
            command0,
            command1
        };
        _turnManager.ExecuteCommands(commands);
    }
}