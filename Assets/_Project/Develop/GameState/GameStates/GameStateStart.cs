using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameStateStart : GameState
{
    [Inject]
    private TurnManager _turnManager;
    [Inject]
    private CommandFabric _commandFabric;

    [Inject(Id = "Enemy")]
    private UnitModel _enemy;

    public GameStateStart(GameStateType gameStateType) : base(gameStateType)
    {
    }

    public override bool CanSwitchToState(GameStateType gameStateType)
    {
        return gameStateType == GameStateType.PlayerTurn;
    }

    public override void OnEnter()
    {
        var command1 = _commandFabric.CreateShowAnimationCommand(ShowAnimationType.Appear, true);
        var command2 = _commandFabric.CreateShowAnimationCommand(ShowAnimationType.Appear, false);

        var strings3 = new List<string>() { "О нет!", string.Format("На тебя нападает {0} !", _enemy.Name)};
        var command3 = _commandFabric.CreateShowMessageCommand(strings3);

        var command4 = _commandFabric.CreateShowAnimationCommand(ShowAnimationType.Shake, false);

        var strings5 = new List<string>() { "Надо срочно что-то делать или станешь жирненьким!",};
        var command5 = _commandFabric.CreateShowMessageCommand(strings5);

        var command6 = _commandFabric.CreateSetGameStateCommand(GameStateType.PlayerTurn);

        var commands = new List<Command>()
        {
            command1,
            command2,
            command3,
            command4,
            command5,
            command6
        };

        _turnManager.ExecuteCommands(commands);     
    }
}