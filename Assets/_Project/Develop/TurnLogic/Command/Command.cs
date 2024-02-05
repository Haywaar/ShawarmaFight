using UnityEngine.Events;

public abstract class Command
{
    protected CommandData _commandData;

    public Command(CommandData data)
    {
        _commandData = data;
    }

    public abstract void Execute(UnityAction onCompleted);
}
