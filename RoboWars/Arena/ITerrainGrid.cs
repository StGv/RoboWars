
namespace RoboWars.Arena
{
    public interface ITerrainGrid
    {
        GridPoint MoveFrom(GridPoint fromPosition, CompassDirection facingDirection);
        bool IsInTerrainLimits(GridPoint position);
    }
}
