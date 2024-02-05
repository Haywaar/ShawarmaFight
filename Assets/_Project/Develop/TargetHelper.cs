using Zenject;

public class TargetHelper
{
    [Inject(Id = "Enemy")]
    private UnitModel _enemy;
    [Inject(Id = "Player")]
    private UnitModel _player;

    public UnitModel GetTarget(TargetType targetType, bool isCasterPlayer)
    {
        switch (targetType)
        {
            case TargetType.Enemy:
                return isCasterPlayer ? _enemy : _player;
            case TargetType.Self:
                 return isCasterPlayer ? _player : _enemy;
            default:
                return isCasterPlayer ? _enemy : _player;
        }
    }
}