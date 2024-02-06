using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSpriteConfig", menuName = "ScriptableObjects/PlayerSpriteConfig", order = 1)]
public class PlayerSpriteConfig : ScriptableObject
{
    [SerializeField] private PlayerSpritePack _leftSpritePack;
    [SerializeField] private PlayerSpritePack _rightSpritePack;
    [SerializeField] private PlayerSpritePack _upSpritePack;
    [SerializeField] private PlayerSpritePack _downSpritePack;

    public PlayerSpritePack LeftSpritePack { get => _leftSpritePack; }
    public PlayerSpritePack RightSpritePack { get => _rightSpritePack; }
    public PlayerSpritePack UpSpritePack { get => _upSpritePack; }
    public PlayerSpritePack DownSpritePack { get => _downSpritePack; }
}
