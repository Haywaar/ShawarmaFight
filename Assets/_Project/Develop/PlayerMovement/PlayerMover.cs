using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 10f;

    private void Update()
    {
        var moveDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.Translate(moveDir * (Time.deltaTime * _movementSpeed));
    }
}
