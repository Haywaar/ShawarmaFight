using System;
using UnityEngine;

public class AttackOptionSlotView : OptionSlotView
{
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _inactiveColor;
    public override void OnInit()
    {
        var attackViewModel = (AbilityViewModel)_viewModel;
        attackViewModel.QuantityChanged += OnQuantityChanged;
        OnQuantityChanged(attackViewModel.Model.Quantity);
    }

    private void OnQuantityChanged(int quantity)
    {
        _slotName.color = quantity == 0 ? _inactiveColor : _defaultColor;
    }
}