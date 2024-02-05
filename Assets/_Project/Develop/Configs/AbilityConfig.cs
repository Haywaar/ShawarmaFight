using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityConfig", menuName = "ScriptableObjects/AbilityConfig", order = 1)]
public class AbilityConfig : ScriptableObject
{
    [SerializeField] private List<AbilityData> _data;

    public List<AbilityData> Data { get => _data; }

    public AbilityData GetAbilityById(int id)
    {
        return Data.First(x => x.Id == id);
    }
}