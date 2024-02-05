using TMPro;
using UnityEngine;

public class ItemOptionSlotView : OptionSlotView
{
    [SerializeField] private TextMeshProUGUI _quantityText;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _noItemColor;
    public override void OnInit()
    {
        var itemViewModel = (ItemViewModel)_viewModel;
        itemViewModel.QuantityChanged += OnQuantityChanged;
        RedrawQuantity();
    }

    private void OnQuantityChanged(int quantity)
    {
        RedrawQuantity();
    }

    private void RedrawQuantity()
    {
        var itemViewModel = (ItemViewModel)_viewModel;
        var isZeroQuantity = itemViewModel.Model.Quantity == 0;
        var prefix = isZeroQuantity ? string.Empty : "x";

        _quantityText.text = prefix + itemViewModel.Model.Quantity.ToString();
        _quantityText.color = isZeroQuantity ? _noItemColor : _defaultColor;
        _slotName.color = isZeroQuantity ? _noItemColor : _defaultColor;
    }
}