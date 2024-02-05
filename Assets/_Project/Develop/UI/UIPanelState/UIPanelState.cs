using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class UIPanelState : MonoBehaviour
{
    protected Dictionary<Vector2, UIPanelOptionViewModel> _viewModels = new Dictionary<Vector2, UIPanelOptionViewModel>();
    protected Vector2 _currentIndex;

    protected UIPanelStateController _stateController;
    protected UIPanelInputController _inputController;

    public abstract void HandleConfirmButtonClicked();
    public abstract void HandleBackButtonClicked();
    public abstract void HandleSelectedSlotChanged(Vector2 xy);
    public abstract UIPanelStateType GetUIPanelStateType();

    public virtual void Activate(bool active)
    {
        gameObject.SetActive(active);

        if (active)
        {
            Subscribe();
        }
        else
        {
            Unsubscribe();
        }
    }

    [Inject]
    public void Construct(UIPanelStateController stateController, UIPanelInputController inputController)
    {
        _stateController = stateController;
        _inputController = inputController;
        _currentIndex = new Vector2(0, 0);
    }

    private void Subscribe()
    {
        _inputController.OnBackButtonClicked += OnBackButtonClicked;
        _inputController.OnConfirmButtonClicked += OnConfirmButtonClicked;
        _inputController.OnSlotIndexChanged += OnSlotIndexChanged;
    }

    private void Unsubscribe()
    {
        _inputController.OnBackButtonClicked -= OnBackButtonClicked;
        _inputController.OnConfirmButtonClicked -= OnConfirmButtonClicked;
        _inputController.OnSlotIndexChanged -= OnSlotIndexChanged;
    }

    private void OnConfirmButtonClicked()
    {
        if (gameObject.activeSelf)
        {
            HandleConfirmButtonClicked();
        }
    }

    private void OnBackButtonClicked()
    {
        if (gameObject.activeSelf)
        {
            HandleBackButtonClicked();
        }
    }

    private void OnSlotIndexChanged(int x, int y)
    {
        if (gameObject.activeSelf)
        {
            HandleSelectedSlotChanged(new Vector2(x, y));
        }
    }
}
