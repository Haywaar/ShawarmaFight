using UnityEngine;
using Zenject;

// Префаб шаурмы
public class ShawarmaProp : MonoBehaviour
{
    private PlayerSpriteRenderer _playerSpriteRenderer;

    [Inject]
    private void Construct(PlayerSpriteRenderer playerSpriteRenderer)
    {
        _playerSpriteRenderer = playerSpriteRenderer;
         Debug.LogWarning("inject for shawarma succesful!");
    }
}