using Zenject;

public abstract class GameState
{
    public GameState(GameStateType gameStateType)
    {
        _gameStateType = gameStateType;
    }
    
    private GameStateType _gameStateType;

    public GameStateType GameStateType { get => _gameStateType; }

    public abstract void OnEnter();

    public abstract bool CanSwitchToState(GameStateType gameStateType);
}
