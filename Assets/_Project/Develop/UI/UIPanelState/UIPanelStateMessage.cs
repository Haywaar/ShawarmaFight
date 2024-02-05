using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UIPanelStateMessage : UIPanelState
{
    [SerializeField] private TextMeshProUGUI _messageText;
    [SerializeField] private float symbolSpeed = 15;
    private bool _confirmButtonClicked;

    private void Start()
    {
        // var strings = new List<string>() {
        //     "Святые бугагашечки!",
        //     "О нет, на тебя напала соблазнительная Шаверма!",
        //     "Если не хочешь быть жирным - победи её!"
        //     };

        // UnityAction callback = () =>
        // {
        //     _stateController.SetPanelState(UIPanelStateType.Menu);
        // };

        // DisplayText(strings, callback);
    }

    public override UIPanelStateType GetUIPanelStateType()
    {
        return UIPanelStateType.Message;
    }

    public override void HandleBackButtonClicked()
    {
        //do nothing
    }

    public override void HandleConfirmButtonClicked()
    {
        _confirmButtonClicked = true;
    }

    public override void HandleSelectedSlotChanged(Vector2 xy)
    {
        //do nothing
    }

    public void DisplayText(List<string> sentences, UnityAction callback)
    {
        StartCoroutine(DisplayTextCoroutine(sentences, callback));
    }

    private IEnumerator DisplayTextCoroutine(List<string> sentences, UnityAction callback)
    {
        _messageText.text = string.Empty;

        float delay = 1f / symbolSpeed;
        foreach (var sentence in sentences)
        {
            _confirmButtonClicked = false;
            for (int i = 0; i < sentence.Length; i++)
            {
                if (_confirmButtonClicked)
                {
                    _messageText.text = sentence;
                    _confirmButtonClicked = false;
                    break;
                }
                _messageText.text += sentence[i];
                yield return new WaitForSeconds(delay);
            }
            yield return new WaitUntil(() => _confirmButtonClicked == true);
            _messageText.text = string.Empty;
        }

        callback?.Invoke();
    }
}