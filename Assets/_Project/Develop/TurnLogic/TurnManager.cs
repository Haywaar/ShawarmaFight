using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public void ExecuteCommands(List<Command> commands)
    {
        //TODO - добавить проверку на то что корутина уже запущена...
        StartCoroutine(ExecuteCommandsCoroutine(commands));
    }

    private IEnumerator ExecuteCommandsCoroutine(List<Command> commands)
    {
        foreach (var command in commands)
        {
            bool commandCompleted = false;
            command.Execute(() =>
            {
                commandCompleted = true;
            });
            yield return new WaitUntil(() => commandCompleted == true);
        }
    }

}