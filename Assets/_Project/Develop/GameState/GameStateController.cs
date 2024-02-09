using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameStateController : MonoBehaviour
{
    private GameState _currentGameState;
    private GameStateType _prevGameState;
    private GameStateFabric _fabric;

    public GameStateType PrevGameState { get => _prevGameState; }

    private Dictionary<GameStateType, GameState> _states = new Dictionary<GameStateType, GameState>();

    [Inject]
    private void Construct(GameStateFabric fabric)
    {
        _fabric = fabric;
    }

    private void Start()
    {
        _currentGameState = _fabric.CreateGameState(GameStateType.GameStart);
        _prevGameState = GameStateType.GameStart;
        _currentGameState.OnEnter();
    }

    public void SetState(GameStateType gameStateType)
    {
        if (_currentGameState.CanSwitchToState(gameStateType))
        {
            GameState newGameState;
            if (_states.ContainsKey(gameStateType))
            {
                newGameState = _states[gameStateType];
            }
            else
            {
                newGameState = _fabric.CreateGameState(gameStateType);
                _states.Add(gameStateType, newGameState);
            }
            _prevGameState = _currentGameState.GameStateType;
            _currentGameState = newGameState;
            newGameState.OnEnter();
        }
    }
}
