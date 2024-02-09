using UnityEngine;
using Zenject;

public class WalkingSceneInstaller : MonoInstaller
{
    [SerializeField] private PlayerSpriteRenderer _playerSpriteRenderer;
    public override void InstallBindings()
    {
        Container.Bind<PlayerSpriteRenderer>().FromInstance(_playerSpriteRenderer);
    }
}