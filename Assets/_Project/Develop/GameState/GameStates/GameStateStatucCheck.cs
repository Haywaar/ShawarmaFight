
using UnityEngine;
using Zenject;

public class GameStateStatusCheck : GameState
{
    [Inject(Id = "Enemy")]
    private UnitModel _enemy;
    [Inject(Id = "Player")]
    private UnitModel _player;

     [Inject]
    private GameStateController _gameStateController;
    
    public GameStateStatusCheck(GameStateType gameStateType) : base(gameStateType)
    {
    }

    public override bool CanSwitchToState(GameStateType gameStateType)
    {
        return true;
    }

    public override void OnEnter()
    {
        Debug.LogWarning("Game state status check!");

        if(_player.Health <= 0 && _enemy.Health > 0)
        {
            _gameStateController.SetState(GameStateType.Lose);
            return;
        }

        if(_gameStateController.PrevGameState == GameStateType.PlayerTurn)
        {
            Debug.LogWarning("Player turn done!");
            _gameStateController.SetState(GameStateType.EnemyTurn);
            return;
        }
        else if(_gameStateController.PrevGameState == GameStateType.EnemyTurn)
        {
             Debug.LogWarning("Enemy turn done!");
            _gameStateController.SetState(GameStateType.PlayerTurn);
            return;
        }
    }
}