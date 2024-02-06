public class LoadSceneData : CommandData
{
    public readonly string SceneName;

    public LoadSceneData(string sceneName)
    {
        SceneName = sceneName;
    }
}