using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitStatusHealthBar : MonoBehaviour
{
    [SerializeField] private float _healthFillAnimDuration = 2f;
    [SerializeField] private bool _showHealthText;
    [SerializeField] private Image _healthFillImage;
    [SerializeField] private TextMeshProUGUI _healthValueText;

    [SerializeField] private Color _goodHealthColor;
    [SerializeField] private Color _midHealthColor;
    [SerializeField] private Color _lowHealthColor;

    private int _maxHealth;
    private int _health;

    public void Init(int currentHealth, int maxHealth)
    {
        _health = currentHealth;
        _maxHealth = maxHealth;
        Redraw();
    }

    public void HealthChanged(int newHealth)
    {
        StartCoroutine(RedrawHealthBarCoroutine(newHealth));
    }

    private IEnumerator RedrawHealthBarCoroutine(int newHealth)
    {
        var delta = newHealth - _health;
        var step = (int)Mathf.Sign(delta) * 1;
        var delayStep = Mathf.Abs(_healthFillAnimDuration / delta);

        while (_health != newHealth)
        {
            _health += step;
            Redraw();
            yield return new WaitForSeconds(delayStep);
        }
    }

    private void DisplayText(int curHealth, int maxHealth)
    {
        if (_showHealthText)
        {
            _healthValueText.text = string.Format("{0}/{1}", curHealth, maxHealth);
        }
    }

    private void Redraw()
    {
        var healthFillvalue = (float)_health / (float)_maxHealth;
        _healthFillImage.fillAmount = healthFillvalue;
        if (healthFillvalue > 0.7f)
        {
            _healthFillImage.color = _goodHealthColor;
        }
        else if (healthFillvalue > 0.45f)
        {
            _healthFillImage.color = _midHealthColor;
        }
        else
        {
            _healthFillImage.color = _lowHealthColor;
        }

        DisplayText(_health, _maxHealth);
    }
}