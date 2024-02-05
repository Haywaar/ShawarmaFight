using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TickManager : MonoBehaviour
{
    public void InvokeWithDelay(UnityAction unityAction, float delayInSeconds)
    {
        StartCoroutine(InvokeWithDelayCoroutine(unityAction, delayInSeconds));
    }

    private IEnumerator InvokeWithDelayCoroutine(UnityAction unityAction, float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        unityAction?.Invoke();
    }
}