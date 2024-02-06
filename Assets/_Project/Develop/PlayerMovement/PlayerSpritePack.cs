using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSpritePack
{
    [SerializeField] private Sprite _idleSprite;
    [SerializeField] private  List<Sprite> _spriteSequence;

    public List<Sprite> SpriteSequence { get => _spriteSequence; set => _spriteSequence = value; }
    public Sprite IdleSprite { get => _idleSprite; set => _idleSprite = value; }
}