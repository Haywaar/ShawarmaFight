using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class EncounterSpawner : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _minEncounterSpawnTime = 4f;
    [SerializeField] private float _maxEncounterSpawnTime = 10f;
    private float _randomEncounterTime;
    private float _walkingTime;
    private bool _encounterStarted;

    private void Start()
    {
        _randomEncounterTime = Random.Range(_minEncounterSpawnTime, _maxEncounterSpawnTime);
    }

    private void Update()
    {
        var moveDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        if (moveDir.x != 0 || moveDir.y != 0)
        {
            _walkingTime += Time.deltaTime;
            if (_walkingTime > _randomEncounterTime && _encounterStarted == false)
            {
                var tween1 = _camera.DOFieldOfView(20, 0.2f);
                var tween2 = _camera.DOFieldOfView(60, 0.2f);
                var sequence = DOTween.Sequence();
                sequence.Append(tween1);
                sequence.Append(tween2);
                sequence.SetLoops(3);

                _encounterStarted = true;

                sequence.onComplete += () =>
            {
                SceneManager.LoadScene(StringConstants.GAME_SCENE_NAME);
            };
            }
        }
    }
}
