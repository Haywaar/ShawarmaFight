using UnityEngine;
using Zenject;

public class GameStateFabric
{
    private DiContainer _container;

    [Inject]
    public void Construct(DiContainer container)
    {
        _container = container;
    }

    public GameState CreateGameState(GameStateType gameStateType)
    {
        GameState gameState;
        switch (gameStateType)
        {
            case GameStateType.GameStart:
                gameState = new GameStateStart(gameStateType);
                break;
            case GameStateType.PlayerTurn:
                gameState = new GameStatePlayerTurn(gameStateType);
                break;
            case GameStateType.GameStatusCheck:
                gameState = new GameStateStatusCheck(gameStateType);
                break;
            case GameStateType.EnemyTurn:
                gameState = new GameStateEnemyTurn(gameStateType);
                break;
            case GameStateType.Lose:
                gameState = new GameStateLose(gameStateType);
                break;
            case GameStateType.Win:
                gameState = new GameStateWin(gameStateType);
                break;
            default:
                Debug.LogErrorFormat("No switch-case for gamestateType {0}", gameStateType);
                gameState = new GameStateStart(gameStateType);
                break;
        }

        _container.Inject(gameState);
        return gameState;
    }
}