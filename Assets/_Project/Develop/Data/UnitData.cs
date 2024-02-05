using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitData
{
    [SerializeField] protected string _name;
    [SerializeField] protected int _health;
    [SerializeField] protected int _maxHealth;
    [SerializeField] protected int _level;
    [SerializeField] protected bool _isEnemy;
    [SerializeField] private List<UnitAbility> unitAbilities;
    [SerializeField] private List<UnitItem> _unitItems;

    public string Name { get => _name; }
    public int Health { get => _health; }
    public int MaxHealth { get => _maxHealth; }
    public int Level { get => _level; }
    public bool IsEnemy { get => _isEnemy; }
    public List<UnitAbility> UnitAbilities { get => unitAbilities; }
    public List<UnitItem> UnitItems { get => _unitItems; }
}