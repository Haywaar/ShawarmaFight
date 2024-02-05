using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private List<EffectModel> _itemEffects;

    public int Id { get => _id; }
    public string Name { get => _name; }
    public string Description { get => _description; }
    public List<EffectModel>  ItemEffects { get => _itemEffects; }
}