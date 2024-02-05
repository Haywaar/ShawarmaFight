using UnityEngine.Events;
using Zenject;

public class SetMenuStateCommand : Command
{
    private UIPanelStateController _panelStateController;

    [Inject]
    private void Construct(UIPanelStateController panelStateController)
    {
        _panelStateController = panelStateController;
    }

    public SetMenuStateCommand(SetMenuStateData data) : base(data)
    {
    }

    public override void Execute(UnityAction onCompleted)
    {
        var menuStateData = (SetMenuStateData)_commandData;
        _panelStateController.SetPanelState(menuStateData.UIPanelStateType);
        onCompleted?.Invoke();
    }
}