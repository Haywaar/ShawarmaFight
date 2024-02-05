using System;
using UnityEngine;

public abstract class UIPanelInputController : MonoBehaviour
{
    public event Action OnConfirmButtonClicked;
    public event Action OnBackButtonClicked;
    public event Action<int, int> OnSlotIndexChanged;

    public abstract void OnUpdate();

    protected void ConfirmButtonClicked()
    {
        OnConfirmButtonClicked?.Invoke();
    }

    protected void BackButtonClicked()
    {
        OnBackButtonClicked?.Invoke();
    }

    protected void RowIndexChanged(int indexDelta)
    {
        OnSlotIndexChanged?.Invoke(0, indexDelta);
    }

    protected void ColumnIndexChanged(int indexDelta)
    {
        OnSlotIndexChanged?.Invoke(indexDelta, 0);
    }
}