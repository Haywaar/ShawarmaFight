public class SetMenuStateData : CommandData
{
    private UIPanelStateType _uIPanelStateType;

    public UIPanelStateType UIPanelStateType { get => _uIPanelStateType; }

    public SetMenuStateData(UIPanelStateType uIPanelStateType)
    {
        _uIPanelStateType = uIPanelStateType;
    }
}