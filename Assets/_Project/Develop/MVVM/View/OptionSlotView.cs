using TMPro;
using UnityEngine;

public abstract class OptionSlotView : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _slotName;
    [SerializeField] private GameObject _selectedBlock;
    protected UIPanelOptionViewModel _viewModel;

    private bool _isSelected;

    public void Init(UIPanelOptionViewModel viewModel)
    {
        _viewModel = viewModel;
        _viewModel.SelectionChanged += SetSelected;
        
        SetSelected(viewModel.IsSelected);
        _slotName.text = _viewModel.Name;

        OnInit();
    }

    public void SetSelected(bool isSelected)
    {
        _isSelected = isSelected;
        _selectedBlock.SetActive(isSelected);
    }

    public abstract void OnInit();
}
