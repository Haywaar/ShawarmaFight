using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameStateStart : GameState
{
    [Inject]
    private TurnManager _turnManager;

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
        Debug.LogWarning("Game state start!");

        var command1 = _turnManager.CreateShowAnimationCommand(ShowAnimationType.Appear, true);
        var command2 = _turnManager.CreateShowAnimationCommand(ShowAnimationType.Appear, false);

        var strings3 = new List<string>() { "О нет!", string.Format("На тебя нападает {0} !", _enemy.Name)};
        var command3 = _turnManager.CreateShowMessageCommand(strings3);

        var command4 = _turnManager.CreateShowAnimationCommand(ShowAnimationType.Shake, false);

        var strings5 = new List<string>() { "Надо срочно что-то делать или станешь жирненьким!",};
        var command5 = _turnManager.CreateShowMessageCommand(strings5);

        var command6 = _turnManager.CreateSetGameStateCommand(GameStateType.PlayerTurn);

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