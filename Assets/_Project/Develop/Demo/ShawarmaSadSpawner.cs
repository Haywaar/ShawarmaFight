using UnityEngine;
using Zenject;

public class ShawarmaSadSpawner : MonoBehaviour
{
    [SerializeField] private ShawarmaProp _shawarmaProp;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;

    [Inject]
    private ShawarmaPool pool;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //var go = Instantiate(_shawarmaProp);
            var go = pool.Spawn();
            go.transform.position = GetRandomPosition();
        }
    }

    private Vector3 GetRandomPosition()
    {
        var randomX = Random.Range(_minX, _maxX);
        var randomY = Random.Range(_minY, _maxY);
        return new Vector3(randomX, randomY, 0f);
    }
}