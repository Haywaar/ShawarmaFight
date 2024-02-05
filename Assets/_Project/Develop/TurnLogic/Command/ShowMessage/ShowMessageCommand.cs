using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class ShowMessageCommand : Command
{
    private UIPanelStateMessage _uIPanelStateMessage;

    [Inject]
    private void Construct(UIPanelStateMessage uIPanelStateMessage)
    {
        _uIPanelStateMessage = uIPanelStateMessage;
    }

    public ShowMessageCommand(ShowMessageData data) : base(data)
    {
    }

    public override void Execute(UnityAction onCompleted)
    {
        var showMessageData = (ShowMessageData)_commandData;
        _uIPanelStateMessage.DisplayText(showMessageData.Sentences, onCompleted);
    }
}