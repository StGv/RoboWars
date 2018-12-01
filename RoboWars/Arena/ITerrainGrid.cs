
namespace RoboWars.Arena
{
    public interface ITerrainGrid
    {
        GridPoint Explore(GridPoint fromPosition, CompassDirection facingDirection);
        bool IsInTerrainLimits(GridPoint position);
    }
}
