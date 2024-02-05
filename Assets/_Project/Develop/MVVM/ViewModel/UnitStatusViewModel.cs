using System;

public class UnitStatusViewModel
{
    private UnitModel _model;

    public string Name => _model.Name;
    public int Health => _model.Health;
    public int MaxHealth => _model.MaxHealth;
    public int Level => _model.Level;
    public event Action<int> HealthChanged;
    public event Action Shake;
    public event Action Appear;
    public UnitStatusViewModel(UnitModel model)
    {
        _model = model;
        _model.HealthChanged += (health) => HealthChanged?.Invoke(health);
    }

    public void ShakeIcon()
    {
        Shake?.Invoke();
    }

    public void AppearIcon()
    {
        Appear?.Invoke();
    }
}