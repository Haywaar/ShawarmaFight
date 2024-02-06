using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LoadSceneCommand : Command
{
    public LoadSceneCommand(LoadSceneData data) : base(data)
    {
    }

    public override void Execute(UnityAction onCompleted)
    {
        var sceneData = (LoadSceneData)_commandData;
        var op = SceneManager.LoadSceneAsync(sceneData.SceneName, LoadSceneMode.Single);
        op.completed += (x) =>
        {
            onCompleted?.Invoke();
        };
    }
}