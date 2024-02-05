using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameConfigInstaller", menuName = "Installers/GameConfigInstaller")]
public class GameConfigInstaller : ScriptableObjectInstaller<GameConfigInstaller>
{
    [SerializeField] private GameConfig gameConfig;
    public override void InstallBindings()
    {
        Container.Bind<MenuOptionConfig>().FromInstance(gameConfig.MenuOptionConfig);
        Container.Bind<ItemsConfig>().FromInstance(gameConfig.ItemsConfig);
        Container.Bind<AbilityConfig>().FromInstance(gameConfig.AbilityConfig);

        var playerModel = ModelFactory.CreateUnitModel(gameConfig.PlayerConfig.UnitData, gameConfig.AbilityConfig.Data, gameConfig.ItemsConfig.Data);
        Container.Bind<UnitModel>().WithId("Player").FromInstance(playerModel);
        var playerStatusViewModel = new PlayerStatusViewModel(playerModel);
        Container.Bind<PlayerStatusViewModel>().FromInstance(playerStatusViewModel);

        var enemyModel = ModelFactory.CreateUnitModel(gameConfig.EnemyConfig.UnitData, gameConfig.AbilityConfig.Data, gameConfig.ItemsConfig.Data);
        Container.Bind<UnitModel>().WithId("Enemy").FromInstance(enemyModel);

        var enemyStatusViewModel = new UnitStatusViewModel(enemyModel);
        Container.Bind<UnitStatusViewModel>().FromInstance(enemyStatusViewModel);
    }
}