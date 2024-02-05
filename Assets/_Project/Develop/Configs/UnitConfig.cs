
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitConfig", menuName = "ScriptableObjects/UnitConfig", order = 1)]
public class UnitConfig : ScriptableObject
{
    [SerializeField] private UnitData _unitData;

    public UnitData UnitData { get => _unitData;  }
}