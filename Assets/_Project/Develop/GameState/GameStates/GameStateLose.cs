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
        var strings = new List<string> { "Ну ты и жирдяй!", "Тебя победила еда!", "АХАХАХАХАХА!!!" };
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