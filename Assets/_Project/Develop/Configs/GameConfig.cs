using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig", order = 1)]
public class GameConfig : ScriptableObject
{
    [SerializeField] private MenuOptionConfig _menuOptionConfig;
    [SerializeField] private ItemsConfig _itemsConfig;
    [SerializeField] private AbilityConfig _abilityConfig;
    [SerializeField] private UnitConfig _enemyConfig;
    [SerializeField] private UnitConfig _playerConfig;

    public MenuOptionConfig MenuOptionConfig { get => _menuOptionConfig; }
    public ItemsConfig ItemsConfig { get => _itemsConfig; }
    public AbilityConfig AbilityConfig { get => _abilityConfig; }
    public UnitConfig PlayerConfig { get => _playerConfig; }
    public UnitConfig EnemyConfig { get => _enemyConfig; }
}