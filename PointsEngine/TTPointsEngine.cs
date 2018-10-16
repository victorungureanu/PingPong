using System;
using System.Drawing;


namespace PointsEngine
{
    public class TTPointsEngine : ITTPointsEngine
    {
        public TTPointsEngine()
        {

        }

        public Direction DetermineDirectionOfBall(Coordinates previousPosition, Coordinates currentPosition)
        {
            if(previousPosition.X < currentPosition.X && previousPosition.Y < currentPosition.Y)
            {
                return Direction.SouthEast;
            }
            else if (previousPosition.X == currentPosition.X && previousPosition.Y < currentPosition.Y)
            {
                return Direction.South;
            }
            else if (previousPosition.X > currentPosition.X && previousPosition.Y < currentPosition.Y)
            {
                return Direction.SouthWest;
            }
            else if (previousPosition.X < currentPosition.X && previousPosition.Y == currentPosition.Y)
            {
                return Direction.East;
            }
            else if (previousPosition.X < currentPosition.X && previousPosition.Y > currentPosition.Y)
            {
                return Direction.NorthEast;
            }
            else if (previousPosition.X == currentPosition.X && previousPosition.Y > currentPosition.Y)
            {
                return Direction.North;
            }
            else if (previousPosition.X > currentPosition.X && previousPosition.Y > currentPosition.Y)
            {
                return Direction.NorthWest;
            }
            else if (previousPosition.X > currentPosition.X && previousPosition.Y == currentPosition.Y)
            {
                return Direction.West;
            };

            return Direction.Unknown;
        }
    }
}
