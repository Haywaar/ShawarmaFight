using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitModel
{
    private string _name;
    private int _health;
    private int _maxHealth;
    private int _level;
    private List<AbilityModel> _abilities;
    private List<ItemModel> _items;

    public int Health { get => _health; }
    public int Level { get => _level; }
    public string Name { get => _name; }
    public int MaxHealth { get => _maxHealth; }
    public List<AbilityModel> Abilities { get => _abilities; }

    public event Action<int> HealthChanged;
    public List<ItemModel> Items { get => _items; }
    public UnitModel(UnitData unitData, List<AbilityModel> abilities, List<ItemModel> items)
    {
        _name = unitData.Name;
        _health = unitData.Health;
        _maxHealth = unitData.MaxHealth;
        _level = unitData.Level;
        _abilities = abilities;
        _items = items;
    }

    public void AddHealth(int value)
    {
        if (value < 0)
        {
            Debug.LogError("Серёжа, ты зачем отрицательные числа вставляешь, лось ты сонный, хватит спать!");
            return;
        }

        _health += value;
        _health = Mathf.Min(_health, _maxHealth);

        HealthChanged?.Invoke(_health);
    }

    public void SubstractHealth(int value)
    {
        if (value < 0)
        {
            Debug.LogError("Серёжа, ты зачем отрицательные числа вставляешь, лось ты сонный, хватит спать!");
            return;
        }

        _health -= value;
        _health = Mathf.Max(_health, 0);

        HealthChanged?.Invoke(_health);
    }
}