using System;

public class ItemViewModel : UIPanelOptionViewModel
{
    public ItemModel Model => _model;
    private ItemModel _model;
    public event Action<int> QuantityChanged;

    public ItemViewModel(string name, bool isSelected, ItemModel itemModel) : base(name, isSelected)
    {
        _model = itemModel;
        _model.QuantityChanged += (x) =>
        {
            QuantityChanged?.Invoke(x);
        };
    }
}
