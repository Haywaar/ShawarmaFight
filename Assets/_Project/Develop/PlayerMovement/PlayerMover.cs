using UnityEngine;
using Zenject;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 10f;

    private PlayerSpriteRenderer _playerSpriteRenderer;

    [Inject]
    private void Construct(PlayerSpriteRenderer playerSpriteRenderer)
    {
        _playerSpriteRenderer = playerSpriteRenderer;
    }

    private void Update()
    {
        var moveDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        _playerSpriteRenderer.MoveDone(moveDir);
        transform.Translate(moveDir * (Time.deltaTime * _movementSpeed));
    }
}
