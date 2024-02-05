using UnityEngine;
using Zenject;

public class UIPanelStateMenu : UIPanelState
{
    [SerializeField] private MenuOptionSlotView _slotPrefab;
    [SerializeField] private Transform _root;
    private MenuOptionConfig _config;

    [Inject]
    public void Construct(MenuOptionConfig menuOptionConfig)
    {
        _config = menuOptionConfig;
    }

    private void Start()
    {
        for (int i = 0; i < _config.Data.Count; i++)
        {
            var menuOption = _config.Data[i];
            var slot = Instantiate(_slotPrefab, _root);
            int rowIndex = i % 2;
            int columnIndex = i / 2;
            var vm = new MenuOptionViewModel(menuOption.Name, i == 0, menuOption.MenuOptionType);
            _viewModels.Add(new Vector2(columnIndex, rowIndex), vm);
            slot.Init(vm);
        }
    }

    public override void HandleBackButtonClicked()
    {
        // do nothing
    }

    public override void HandleConfirmButtonClicked()
    {
        var vm = (MenuOptionViewModel) _viewModels[_currentIndex];

        switch (vm.OptionType)
        {
            case MenuOptionType.Attack:
                _stateController.SetPanelState(UIPanelStateType.Attack);
                break;
            case MenuOptionType.Items:
                _stateController.SetPanelState(UIPanelStateType.Items);
                break;
            case MenuOptionType.Run:
                // СЁРЕЖА НЕ УБЕГАЕТ!
                break;
        }
    }

    public override void HandleSelectedSlotChanged(Vector2 vectorDelta)
    {
        var newIndex = _currentIndex + vectorDelta;
        if (_viewModels.ContainsKey(newIndex))
        {
            var newVM = _viewModels[newIndex];
            if (newVM != null)
            {
                newVM.SetSelected(true);

                var oldVM = _viewModels[_currentIndex];
                oldVM.SetSelected(false);
                _currentIndex = newIndex;
            }
        }
    }

    public override UIPanelStateType GetUIPanelStateType()
    {
        return UIPanelStateType.Menu;
    }
}