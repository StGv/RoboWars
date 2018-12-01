using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWars.Arena
{
    public enum CompassDirection
    {
        NORTH = 'N',
        EAST = 'E',
        SOUTH = 'S',
        WEST = 'W',
    }

    public static class CompassExtentions
    {
        public static CompassDirection ToRight(this CompassDirection CurrentCompassOrientation)
        {
            switch (CurrentCompassOrientation)
            {
                case CompassDirection.NORTH:
                    return CompassDirection.EAST;
                case CompassDirection.SOUTH:
                    return CompassDirection.WEST;
                case CompassDirection.EAST:
                    return CompassDirection.SOUTH;
                case CompassDirection.WEST:
                    return CompassDirection.NORTH;
                default:
                    return CurrentCompassOrientation;
            }
        }

        public static CompassDirection ToLeft(this CompassDirection CurrentCompassOrientation)
        {
            switch (CurrentCompassOrientation)
            {
                case CompassDirection.NORTH:
                    return CompassDirection.WEST;
                case CompassDirection.SOUTH:
                    return CompassDirection.EAST;
                case CompassDirection.EAST:
                    return CompassDirection.NORTH;
                case CompassDirection.WEST:
                    return CompassDirection.SOUTH;
                default:
                    return CurrentCompassOrientation;
            }
        }
    }
}
