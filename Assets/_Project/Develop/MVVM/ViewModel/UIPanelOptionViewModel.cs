using System;
using UnityEditor.UI;

public abstract class UIPanelOptionViewModel
{
    private string _name;
    private bool _isSelected;

    public bool IsSelected { get => _isSelected; }
    public string Name { get => _name; }

    public event Action<bool> SelectionChanged;

    public UIPanelOptionViewModel(string name, bool isSelected)
    {
        _name = name;
        _isSelected = isSelected;
    }

    public void SetSelected(bool isSelected)
    {
        _isSelected = isSelected;
        SelectionChanged?.Invoke(isSelected);
    }
}