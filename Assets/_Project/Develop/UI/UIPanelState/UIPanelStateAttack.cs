using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class UIPanelStateAttack : UIPanelState
{
    [SerializeField] private TextMeshProUGUI _attackType;
    [SerializeField] private TextMeshProUGUI _attackQuantity;
    [SerializeField] private TextMeshProUGUI _attackDescription;
    [SerializeField] private AttackOptionSlotView _slotPrefab;
    [SerializeField] private Transform _root;

    private List<AbilityModel> _abilities = new List<AbilityModel>();
    private SignalBus _signalBus;

    [Inject(Id = "Player")]
    private UnitModel _playerModel;

    public override UIPanelStateType GetUIPanelStateType()
    {
        return UIPanelStateType.Attack;
    }

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    private void Start()
    {
         _abilities = _playerModel.Abilities;

        for (int i = 0; i < _abilities.Count; i++)
        {
            var attackModel = _abilities[i];
            var slot = Instantiate(_slotPrefab, _root);
            int columnIndex = 0;
            int rowIndex = i;
            var vm = new AbilityViewModel(attackModel.Name, i == 0, attackModel);
            _viewModels.Add(new Vector2(columnIndex, rowIndex), vm);

            slot.Init(vm);
        }

        Redraw(_viewModels[new Vector2(0,0)]);
    }

    public override void HandleBackButtonClicked()
    {
        _stateController.SetPanelState(UIPanelStateType.Menu);
    }

    public override void HandleConfirmButtonClicked()
    {
        var abilityVM = (AbilityViewModel)_viewModels[_currentIndex];

        if (abilityVM.Model.Quantity > 0)
        {
            _signalBus.Fire(new PlayerUsedAbilitySignal(abilityVM.Model));
            Redraw(_viewModels[_currentIndex]);
        }
        else
        {
            // send signal - no abilities
        }
    }

    public override void HandleSelectedSlotChanged(Vector2 vectorDelta)
    {
        var newIndex = _currentIndex + new Vector2(0, vectorDelta.y);
        Debug.LogWarning("new index is " + newIndex + "panel active self " + gameObject.activeSelf + " " + gameObject.name);

        if (_viewModels.ContainsKey(newIndex) && _currentIndex != newIndex)
        {
            var newVM = _viewModels[newIndex];
            if (newVM != null)
            {
                newVM.SetSelected(true);
                Redraw(newVM);

                var oldVM = _viewModels[_currentIndex];
                oldVM.SetSelected(false);
                _currentIndex = newIndex;
            }
        }
    }

    private void Redraw(UIPanelOptionViewModel uIPanelOptionViewModel)
    {
        var vm = (AbilityViewModel)uIPanelOptionViewModel;
        _attackType.text = vm.Model.AttackType.ToString();
        _attackQuantity.text = vm.Model.Quantity.ToString() + "/" + vm.Model.MaxQuantity.ToString();
        _attackDescription.text = vm.Model.Description;
    }
}