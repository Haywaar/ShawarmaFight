using UnityEngine;

public class UIPanelKeyboardInputController : UIPanelInputController
{
    private void LateUpdate()
    {
        OnUpdate();
    }

    public override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ConfirmButtonClicked();
            return;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            BackButtonClicked();
            return;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            RowIndexChanged(1);
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            RowIndexChanged(-1);
            return;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ColumnIndexChanged(1);
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ColumnIndexChanged(-1);
            return;
        }
    }
}