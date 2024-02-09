using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
    [SerializeField] private PlayerSpriteConfig _config;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _frameDelay = 0.2f;

    private int _spriteIndex;
    private float _curFrameDelay;
    private Vector3 _prevDirection;

    public void MoveDone(Vector3 moveDir)
    {
        _curFrameDelay += Time.deltaTime;
        if (_curFrameDelay < _frameDelay)
        {
            return;
        }

        _curFrameDelay = 0f;
        if (moveDir.x != 0 && moveDir.y != 0)
        {
            _prevDirection = moveDir;
        }

        // Идём вправо
        if (moveDir.x > 0)
        {
            SetSprite(_config.RightSpritePack);
        }
        // Идём влево
        else if (moveDir.x < 0)
        {
            SetSprite(_config.LeftSpritePack);
        }
        // Идём вверх
        else if (moveDir.y > 0)
        {
            SetSprite(_config.UpSpritePack);
        }
        // Идём вниз
        else if (moveDir.y < 0)
        {
            SetSprite(_config.DownSpritePack);
        }

        if (moveDir.x == 0 && moveDir.y == 0)
        {
            SetIdleSprite();
        }
    }

    private void SetSprite(PlayerSpritePack playerSpritePack)
    {
        if (_spriteIndex >= playerSpritePack.SpriteSequence.Count)
        {
            _spriteIndex = 0;
        }

        _spriteRenderer.sprite = playerSpritePack.SpriteSequence[_spriteIndex];
        _spriteIndex++;
    }

    private void SetIdleSprite()
    {
        if (_prevDirection.x > 0)
        {
            _spriteRenderer.sprite = _config.RightSpritePack.IdleSprite;
        }
        else if (_prevDirection.x < 0)
        {
            _spriteRenderer.sprite = _config.LeftSpritePack.IdleSprite;
        }
        else if (_prevDirection.y > 0)
        {
            _spriteRenderer.sprite = _config.UpSpritePack.IdleSprite;
        }
        else if (_prevDirection.y < 0)
        {
            _spriteRenderer.sprite = _config.DownSpritePack.IdleSprite;
        }
    }
}