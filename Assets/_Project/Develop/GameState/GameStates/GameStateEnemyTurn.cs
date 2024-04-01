using System.Collections.Generic;
using Zenject;

public class GameStateEnemyTurn : GameState
{
    [Inject(Id = "Enemy")]
    private UnitModel _enemy;
    [Inject]
    private TargetHelper _targetHelper;
    [Inject]
    private CommandFabric _commandFabric;

    [Inject]
    private TurnManager _turnManager;

    public GameStateEnemyTurn(GameStateType gameStateType) : base(gameStateType)
    {
    }

    public override bool CanSwitchToState(GameStateType gameStateType)
    {
        return gameStateType == GameStateType.GameStatusCheck;
    }

    public override void OnEnter()
    {
        // use random enemy ability from enemy config
        var randomAbilityId = UnityEngine.Random.Range(0, _enemy.Abilities.Count);
        var ability = _enemy.Abilities[randomAbilityId];

        var command0 = _commandFabric.CreateSetMenuStateCommand(UIPanelStateType.Message);

        var abilityStrings = new List<string>() { string.Format("{0} использует {1}",_enemy.Name, ability.Name) };
        var command1 = _commandFabric.CreateShowMessageCommand(abilityStrings);
        var commandPunch = _commandFabric.CreateShowAnimationCommand(ShowAnimationType.Punch, true);

        var effectCommands = new List<Command>();
        foreach (var effect in ability.Effects)
        {
            var target = _targetHelper.GetTarget(effect.TargetType, false);
            var command = _commandFabric.CreateApplyEffectCommand(effect, target);
            effectCommands.Add(command);
        }
        var command3 = _commandFabric.CreateSetMenuStateCommand(UIPanelStateType.Menu);
        var command4 = _commandFabric.CreateSetGameStateCommand(GameStateType.GameStatusCheck);

        var commands = new List<Command>()
        {
            command0,
            command1,
            commandPunch
        };

        commands.AddRange(effectCommands);
        commands.Add(command3);
        commands.Add(command4);
        _turnManager.ExecuteCommands(commands);
    }
}