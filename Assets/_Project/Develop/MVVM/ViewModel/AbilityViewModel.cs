using System;

public class AbilityViewModel : UIPanelOptionViewModel
{
    public AbilityModel Model => _model;
    private AbilityModel _model;
    public event Action<int> QuantityChanged;

    public AbilityViewModel(string name, bool isSelected, AbilityModel attackModel) : base(name, isSelected)
    {
        _model = attackModel;
        _model.QuantityChanged += (x) =>
       {
           QuantityChanged?.Invoke(x);
       };
    }
}
