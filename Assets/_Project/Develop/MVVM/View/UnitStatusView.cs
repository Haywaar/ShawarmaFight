using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UnitStatusView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _unitName;
    [SerializeField] private TextMeshProUGUI _lvlText;
    [SerializeField] private UnitStatusHealthBar _healthBar;
    [SerializeField] private Image _unitImage;
    [SerializeField] private RectTransform _unitImagePosition;

    [SerializeField] private bool _isPlayer;
    private UnitStatusViewModel _viewModel;

    [Inject]
    public void Construct(PlayerStatusViewModel playerStatusViewModel, UnitStatusViewModel enemyStatusViewModel)
    {
        if (_isPlayer)
        {
            Init(playerStatusViewModel);
        }
        else
        {
            Init(enemyStatusViewModel);
        }
    }
    private void Init(UnitStatusViewModel viewModel)
    {
        _viewModel = viewModel;
        _unitName.text = _viewModel.Name;
        _lvlText.text = "LVL " + _viewModel.Level;
        _viewModel.HealthChanged += OnHealthChanged;
        _healthBar.Init(_viewModel.Health, _viewModel.MaxHealth);

        _viewModel.Shake += OnShake;
        _viewModel.Appear += ShowAppearAnimation;
    }

    private void OnShake()
    {
        _unitImage.transform.DOShakePosition(1.0f, 150, 50);
    }

    private void ShowAppearAnimation()
    {
        _unitImage.transform.DOMove(_unitImagePosition.position, 2.0f, false);
    }

    private void OnHealthChanged(int value)
    {
        _healthBar.HealthChanged(value);
    }
}
