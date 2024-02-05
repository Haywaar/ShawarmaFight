using System.Collections.Generic;
using Zenject;

public class GameStatePlayerTurn : GameState
{
    private SignalBus _signalBus;
    private TurnManager _turnManager;
    private TargetHelper _targetHelper;

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

    private void OnPlayerUsedAbilitySignal(PlayerUsedAbilitySignal playerUsedAbilitySignal)
    {
        playerUsedAbilitySignal.AbilityModel.AbilityUsed();
        var command0 = _turnManager.CreateSetMenuStateCommand(UIPanelStateType.Message);

        var abilityStrings = new List<string>() { string.Format("Серёжа использует {0}", playerUsedAbilitySignal.AbilityModel.Name) };
        var command1 = _turnManager.CreateShowMessageCommand(abilityStrings);

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
        };

        commands.AddRange(effectCommands);
        commands.Add(command3);
        commands.Add(command4);
        _turnManager.ExecuteCommands(commands);
    }

    private void OnItemUsedSignal(ItemUsedSignal itemUsedSignal)
    {
        itemUsedSignal.ItemModel.ItemUsed();

        var itemStrings = new List<string>() { string.Format("Серёжа поглощает {0}", itemUsedSignal.ItemModel.Name) };
        var command0 = _turnManager.CreateSetMenuStateCommand(UIPanelStateType.Message);
        var command1 = _turnManager.CreateShowMessageCommand(itemStrings);

        var effectCommands = new List<Command>();
        foreach(var effect in itemUsedSignal.ItemModel.ItemEffects)
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
}