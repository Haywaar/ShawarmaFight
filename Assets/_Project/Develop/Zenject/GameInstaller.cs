using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
  [SerializeField] private UIPanelKeyboardInputController _inputController;
  [SerializeField] private UIPanelStateController _stateController;
  [SerializeField] private UIPanelStateMenu _menuPanel;
  [SerializeField] private UIPanelStateMessage _messagePanel;
  [SerializeField] private TickManager _tickManager;
  [SerializeField] private TurnManager _turnManager;
  [SerializeField] private GameStateController _gameStateController;

  private EffectApplier _effectApplier;

  public override void InstallBindings()
  {
    SignalBusInstaller.Install(Container);
    Container.DeclareSignal<ItemUsedSignal>().OptionalSubscriber();
    Container.DeclareSignal<PlayerUsedAbilitySignal>().OptionalSubscriber();

    Container.Bind<UIPanelInputController>().FromInstance(_inputController);
    Container.Bind<UIPanelStateController>().FromInstance(_stateController);
    Container.Bind<UIPanelStateMenu>().FromInstance(_menuPanel);
    Container.Bind<UIPanelStateMessage>().FromInstance(_messagePanel);

    Container.Bind<TickManager>().FromInstance(_tickManager);

    var gameStateFabric = new GameStateFabric();
    Container.Bind<GameStateFabric>().FromInstance(gameStateFabric);
    Container.Inject(gameStateFabric);

    _effectApplier = new EffectApplier();
    Container.Inject(_effectApplier);
    Container.Bind<EffectApplier>().FromInstance(_effectApplier);

    Container.Bind<TurnManager>().FromInstance(_turnManager);

    Container.Bind<GameStateController>().FromInstance(_gameStateController);

    var targetHelper = new TargetHelper();
    Container.Bind<TargetHelper>().FromInstance(targetHelper);
    Container.Inject(targetHelper);
  }
}
