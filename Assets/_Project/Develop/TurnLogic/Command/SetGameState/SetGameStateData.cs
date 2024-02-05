public class SetGameStateData : CommandData
{
    private GameStateType _gameStateType;
    public GameStateType GameStateType { get => _gameStateType; }

    public SetGameStateData(GameStateType gameStateType)
    {
        _gameStateType = gameStateType;
    }
}