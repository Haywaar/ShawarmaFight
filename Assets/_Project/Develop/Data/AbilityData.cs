using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbilityData
{
    [SerializeField] private int _id;
    [SerializeField] private string _attackName;
    [SerializeField] private string _description;
    [SerializeField] private AttackType _attackType;
    [SerializeField] private List<EffectModel> _effects;

    public string Name { get => _attackName; }
    public string Description { get => _description; }
    public AttackType AttackType { get => _attackType; }
    public List<EffectModel> Effects { get => _effects; }
    public int Id { get => _id; }
}
