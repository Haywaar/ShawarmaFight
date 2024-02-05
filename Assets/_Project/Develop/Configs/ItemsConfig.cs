using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsConfig", menuName = "ScriptableObjects/ItemsConfig", order = 1)]
public class ItemsConfig : ScriptableObject
{
    [SerializeField] private List<ItemData> _data;

    public List<ItemData> Data { get => _data; }
}