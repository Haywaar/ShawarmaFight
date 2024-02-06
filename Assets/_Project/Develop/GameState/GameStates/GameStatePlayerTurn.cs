using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameStatePlayerTurn : GameState
{
    private SignalBus _signalBus;
    private TurnManager _turnManager;
    private TargetHelper _targetHelper;

    [Inject(Id = "Player")]
    private UnitModel _playerModel;

    public GameStatePlayerTurn(GameStateType gameStateType) : base(gameStateType)
    {
    }

    [Inject]
    public void Construct(SignalBus signalBus, TurnManager turnManager, TargetHelper targetHelper)
    {
        _signalBus = signalBus;
        _turnManager = turnManager;
        _targetHelper = targetHelper;

        _signalBus.Subscribe<ItemUsedSignal>(OnItemUsedSignal);
        _signalBus.Subscribe<PlayerUsedAbilitySignal>(OnPlayerUsedAbilitySignal);
        _signalBus.Subscribe<PlayerRunSignal>(OnPlayerRunSignal);
    }

    public override bool CanSwitchToState(GameStateType gameStateType)
    {
        return gameStateType == GameStateType.GameStatusCheck;
    }

    public override void OnEnter()
    {
        var command3 = _turnManager.CreateSetMenuStateCommand(UIPanelStateType.Menu);

        var commands = new List<Command>()
        {
            command3
        };
        _turnManager.ExecuteCommands(commands);
    }

    private void OnItemUsedSignal(ItemUsedSignal itemUsedSignal)
    {
        itemUsedSignal.ItemModel.ItemUsed();

        var itemStrings = new List<string>() { string.Format("{0} поглощает {1}", _playerModel.Name, itemUsedSignal.ItemModel.Name) };
        var command0 = _turnManager.CreateSetMenuStateCommand(UIPanelStateType.Message);
        var command1 = _turnManager.CreateShowMessageCommand(itemStrings);

        var effectCommands = new List<Command>();
        foreach (var effect in itemUsedSignal.ItemModel.ItemEffects)
        {
            var target = _targetHelper.GetTarget(effect.TargetType, true);
            var command = _turnManager.CreateApplyEffectCommand(effect, target);
            effectCommands.Add(command);
        }

        var command3 = _turnManager.CreateSetMenuStateCommand(UIPanelStateType.Menu);
        var command4 = _turnManager.CreateSetGameStateCommand(GameStateType.GameStatusCheck);

        var commands = new List<Command>(){
            command0,
            command1,
        };
        commands.AddRange(effectCommands);
        commands.Add(command3);
        commands.Add(command4);

        _turnManager.ExecuteCommands(commands);
    }

    private void OnPlayerUsedAbilitySignal(PlayerUsedAbilitySignal playerUsedAbilitySignal)
    {
        playerUsedAbilitySignal.AbilityModel.AbilityUsed();
        var command0 = _turnManager.CreateSetMenuStateCommand(UIPanelStateType.Message);

        var abilityStrings = new List<string>() { string.Format("{0} использует {1}", _playerModel.Name, playerUsedAbilitySignal.AbilityModel.Name) };
        var command1 = _turnManager.CreateShowMessageCommand(abilityStrings);

        var commandPunch = _turnManager.CreateShowAnimationCommand(ShowAnimationType.Punch, false);

        var effectCommands = new List<Command>();
        foreach (var effect in playerUsedAbilitySignal.AbilityModel.Effects)
        {
            var target = _targetHelper.GetTarget(effect.TargetType, true);
            var command = _turnManager.CreateApplyEffectCommand(effect, target);
            effectCommands.Add(command);
        }
        var command3 = _turnManager.CreateSetMenuStateCommand(UIPanelStateType.Menu);
        var command4 = _turnManager.CreateSetGameStateCommand(GameStateType.GameStatusCheck);

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

    private void OnPlayerRunSignal()
    {
        var command0 = _turnManager.CreateSetMenuStateCommand(UIPanelStateType.Message);
        var strings = new List<string> { string.Format("{0} отчаянно пытается сбежать!", _playerModel.Name), "На этот раз ему это удалось!" };
        var command1 = _turnManager.CreateShowMessageCommand(strings);
        var command2 = _turnManager.CreateLoadSceneCommand(StringConstants.WALKING_SCENE_NAME);
        var commands = new List<Command>()
        {
            command0,
            command1,
            command2
        };
        _turnManager.ExecuteCommands(commands);
    }
}