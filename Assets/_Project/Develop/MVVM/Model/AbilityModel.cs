using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbilityModel
{
    private AbilityData _data;
    private int _quantity;
    private int _maxQuantity;

    public AbilityModel(AbilityData data, int quantity, int maxQuantity)
    {
        _data = data;
        _quantity = quantity;
        _maxQuantity = maxQuantity;
    }

    public int Quantity => _quantity;
    public int MaxQuantity => _maxQuantity;
    public string Name => _data.Name;
    public string Description => _data.Description;
    public AttackType AttackType => _data.AttackType;
    public List<EffectModel> Effects { get => _data.Effects; }

    public event Action<int> QuantityChanged;

    public void AbilityUsed()
    {
        if (_quantity - 1 < 0)
        {
            Debug.LogErrorFormat("Can't substract {0} ability when you have only {1}", 1, _quantity);
            return;
        }

        _quantity -= 1;
        QuantityChanged?.Invoke(_quantity);
    }
}
