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

        _viewModel.ShowAnimation += OnShowAnimation;
    }

    private void OnHealthChanged(int value)
    {
        _healthBar.HealthChanged(value);
    }

    private void OnShowAnimation(ShowAnimationType animationType)
    {
        switch (animationType)
        {
            case ShowAnimationType.Appear:
                ShowAppearAnimation();
                break;
            case ShowAnimationType.Shake:
                OnShake();
                break;
            case ShowAnimationType.Punch:
                OnPunch();
                break;
            case ShowAnimationType.Strike:
                OnStrike();

                break;
        }
    }

    private void OnShake()
    {
        _unitImage.transform.DOShakePosition(1.0f, 150, 50);
    }

    private void ShowAppearAnimation()
    {
        _unitImage.transform.DOMove(_unitImagePosition.position, 2.0f, false);
    }

    private void OnPunch()
    {
        _unitImage.transform.DOPunchPosition(new Vector3(80, 0, 0), 1.0f, 30, 1);
    }

    private void OnStrike()
    {
         _unitImage.transform.DOPunchPosition(new Vector3(0, 80, 0), 1.0f, 40, 1);
    }
}
