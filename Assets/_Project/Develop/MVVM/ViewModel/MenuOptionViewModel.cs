using UnityEngine;

public class MenuOptionViewModel : UIPanelOptionViewModel
{
    private MenuOptionType _optionType;
    public MenuOptionType OptionType { get => _optionType; }

    public MenuOptionViewModel(string name, bool isSelected, MenuOptionType optionType) : base(name, isSelected)
    {
        _optionType = optionType;
    }
}
