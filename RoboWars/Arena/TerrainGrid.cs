namespace RoboWars.Arena
{ 

    public class TerrainGrid : ITerrainGrid
    {

        public TerrainGrid(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxX;
        }

        public int MaxX { get; private set; }
        public int MaxY { get; private set; }

        public bool IsInTerrainLimits(GridPoint position)
        {
            return position.X < MaxX && position.Y < MaxY;
        }

        public GridPoint MoveFrom(GridPoint fromPosition, CompassDirection facingDirection)
        {
            switch (facingDirection)
            {
                case CompassDirection.NORTH:
                    return MoveToNorth(fromPosition);
                case CompassDirection.SOUTH:
                    return MoveToSouth(fromPosition);
                case CompassDirection.EAST:
                    return MoveToEast(fromPosition);
                case CompassDirection.WEST:
                    return MoveToWest(fromPosition);
                default:
                    return fromPosition;
            }
        }

        protected GridPoint MoveToNorth(GridPoint fromPosition)
        {
            return (fromPosition.Y + 1 == MaxY)
                ? fromPosition
                : new GridPoint(fromPosition.X, fromPosition.Y + 1);
        }

        protected GridPoint MoveToSouth(GridPoint fromPosition)
        {
            return (fromPosition.Y == 0)
                ? fromPosition
                : new GridPoint(fromPosition.X, fromPosition.Y - 1);
        }

        protected GridPoint MoveToEast(GridPoint fromPosition)
        {
            return (fromPosition.X + 1 == MaxX)
                ? fromPosition
                : new GridPoint(fromPosition.X + 1, fromPosition.Y);
        }
        protected GridPoint MoveToWest(GridPoint fromPosition)
        {
            return (fromPosition.X == 0)
                ? fromPosition
                : new GridPoint(fromPosition.X - 1, fromPosition.Y);
        }
    }
}
