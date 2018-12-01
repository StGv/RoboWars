using RoboWars.Arena;

namespace RoboWars
{
    public enum Commands
    {
        Move = 'M',
        Left = 'L',
        Right = 'R'
    }

    public class Robot
    {
        public CompassDirection CurrentCompassOrientation { get; private set; }
        public GridPoint CurrentGridPosition { get; private set; }

        ITerrainGrid _arenaTerrainGrid;

        public Robot(ITerrainGrid terrain): 
            this(terrain, new GridPoint(0, 0), CompassDirection.NORTH)
        {
        }

        public Robot(ITerrainGrid terrain, GridPoint position, CompassDirection facingDirection)
        {
            if (!terrain.IsInTerrainLimits(position))
                throw new System.ArgumentException($"Specified grid point ({position.X},{position.Y}) is outside arena limits.");

            _arenaTerrainGrid = terrain;
            CurrentCompassOrientation = facingDirection;
            CurrentGridPosition = position;
        }

        public void MoveForward()
        {
            CurrentGridPosition = _arenaTerrainGrid.Explore(CurrentGridPosition, CurrentCompassOrientation);
        }

        public void TurnLeft()
        {
            CurrentCompassOrientation = CurrentCompassOrientation.ToLeft();
        }

        public void TurnRight()
        {
            CurrentCompassOrientation = CurrentCompassOrientation.ToRight();
        }
    }
}
