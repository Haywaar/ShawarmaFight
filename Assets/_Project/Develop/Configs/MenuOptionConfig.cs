using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MenuOptions", menuName = "ScriptableObjects/MenuOptions", order = 1)]
public class MenuOptionConfig : ScriptableObject
{
    [SerializeField] private List<MenuOptionModel> _data;

    public List<MenuOptionModel> Data { get => _data; }
}