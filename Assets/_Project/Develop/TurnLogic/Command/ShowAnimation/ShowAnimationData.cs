public class ShowAnimationData : CommandData
{
    private bool _isPlayer;
    private ShowAnimationType _showAnimationType;
    public bool IsPlayer { get => _isPlayer; }
    public ShowAnimationType AnimationType { get => _showAnimationType; }

    public ShowAnimationData(ShowAnimationType showAnimationType, bool isPlayer)
    {
        _showAnimationType = showAnimationType;
        _isPlayer = isPlayer;
    }
}