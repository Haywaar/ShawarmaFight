using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CommandFabric
{
    private DiContainer _container;

    [Inject]
    public void Construct(DiContainer container)
    {
        _container = container;
    }

     public Command CreateShowMessageCommand(List<string> strings)
    {
        var command = new ShowMessageCommand(new ShowMessageData(strings));
        _container.Inject(command);
        return command;
    }

    public Command CreateApplyEffectCommand(EffectModel effectModel, UnitModel unitModel)
    {
        var command = new ApplyEffectCommand(new ApplyEffectData(effectModel, unitModel));
        _container.Inject(command);
        return command;
    }

    public Command CreateSetMenuStateCommand(UIPanelStateType stateType)
    {
        var command = new SetMenuStateCommand(new SetMenuStateData(stateType));
        _container.Inject(command);
        return command;
    }

    public Command CreateSetGameStateCommand(GameStateType gameStateType)
    {
        var command = new SetGameStateCommand(new SetGameStateData(gameStateType));
        _container.Inject(command);
        return command;
    }

    public Command CreateShowAnimationCommand(ShowAnimationType showAnimationType, bool isPlayer)
    {
        var command = new ShowAnimationCommand(new ShowAnimationData(showAnimationType, isPlayer));
        _container.Inject(command);
        return command;
    }

    public Command CreateLoadSceneCommand(string sceneName)
    {
        var command = new LoadSceneCommand(new LoadSceneData(sceneName));
        _container.Inject(command);
        return command;
    }
}