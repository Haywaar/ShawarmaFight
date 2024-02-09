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
    BindSignals();

    Container.Bind<UIPanelInputController>().FromInstance(_inputController);
    Container.Bind<UIPanelStateController>().FromInstance(_stateController);
    Container.Bind<UIPanelStateMenu>().FromInstance(_menuPanel);
    Container.Bind<UIPanelStateMessage>().FromInstance(_messagePanel);

    Container.Bind<TickManager>().FromInstance(_tickManager);

    var gameStateFabric = new GameStateFabric();
    Container.BindInstance(gameStateFabric);
    Container.QueueForInject(gameStateFabric);

    _effectApplier = new EffectApplier();
    Container.BindInstance(_effectApplier);

    Container.BindInstance(_turnManager);

    Container.BindInstance(_gameStateController);

    var targetHelper = new TargetHelper();
    Container.Bind<TargetHelper>().FromInstance(targetHelper);
    Container.QueueForInject(targetHelper);
  }

  private void BindSignals()
  {
    SignalBusInstaller.Install(Container);

    Container.DeclareSignal<ItemUsedSignal>().OptionalSubscriber();
    Container.DeclareSignal<PlayerUsedAbilitySignal>().OptionalSubscriber();
    Container.DeclareSignal<PlayerRunSignal>().OptionalSubscriber();
  }
}
