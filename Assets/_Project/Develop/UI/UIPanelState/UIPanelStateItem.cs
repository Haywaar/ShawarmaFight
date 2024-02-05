using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class UIPanelStateItem : UIPanelState
{
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private ItemOptionSlotView _slotPrefab;
    [SerializeField] private Transform _root;

    private List<ItemModel> _playerItems;
    private SignalBus _signalBus;
    private bool _inited = false;

    [Inject(Id = "Player")]
    private UnitModel _playerModel;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        
        _signalBus = signalBus;
    }

    private void Start()
    {
        _playerItems = _playerModel.Items;

        for (int i = 0; i < _playerItems.Count; i++)
        {
            var itemModel = _playerItems[i];
            var slot = Instantiate(_slotPrefab, _root);
            int columnIndex = 0;
            int rowIndex = i;
            var vm = new ItemViewModel(itemModel.Name, i == 0, itemModel);
            _viewModels.Add(new Vector2(columnIndex, rowIndex), vm);

            slot.Init(vm);
        }
        _inited = true;
    }

    public override UIPanelStateType GetUIPanelStateType()
    {
        return UIPanelStateType.Items;
    }

    public override void HandleBackButtonClicked()
    {
        _stateController.SetPanelState(UIPanelStateType.Menu);
    }

    public override void HandleConfirmButtonClicked()
    {
        if (_inited == false)
            return;

        if (_stateController.ActiveStateType != GetUIPanelStateType())
            return;

        var itemVM = (ItemViewModel)_viewModels[_currentIndex];

        if (itemVM.Model.Quantity > 0)
        {
            _signalBus.Fire(new ItemUsedSignal(itemVM.Model));
        }
        else
        {
            // send signal - no items
        }
    }

    public override void HandleSelectedSlotChanged(Vector2 vectorDelta)
    {
        var newIndex = _currentIndex + new Vector2(0, vectorDelta.y);

        if (_viewModels.ContainsKey(newIndex) && _currentIndex != newIndex)
        {
            var newVM = _viewModels[newIndex];
            if (newVM != null)
            {
                newVM.SetSelected(true);

                var itemVM = (ItemViewModel)newVM;
                _descriptionText.text = itemVM.Model.Description;

                var oldVM = _viewModels[_currentIndex];
                oldVM.SetSelected(false);
                _currentIndex = newIndex;
            }
        }
    }
}