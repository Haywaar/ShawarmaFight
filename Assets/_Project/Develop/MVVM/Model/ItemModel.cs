using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemModel
{
    private ItemData _data;
    private int _quantity;

    public ItemModel(ItemData data, int quantity)
    {
        _data = data;
        _quantity = quantity;
    }

    public int Id { get => _data.Id; }
    public string Name { get => _data.Name; }
    public string Description { get => _data.Description; }
    public int Quantity { get => _quantity; }
    public event Action<int> QuantityChanged;

    public List<EffectModel> ItemEffects { get => _data.ItemEffects; }

    public void ItemUsed()
    {
        if (_quantity - 1 < 0)
        {
            Debug.LogErrorFormat("Can't substract {0} items when you have only {1}", 1, _quantity);
            return;
        }

        _quantity -= 1;
        QuantityChanged?.Invoke(_quantity);
    }
}