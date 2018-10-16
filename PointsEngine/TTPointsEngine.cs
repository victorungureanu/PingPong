using System.Collections.Generic;
using System.Drawing;

namespace PointsEngine
{
    public class TTPointsEngine : ITTPointsEngine
    {
        public static LinkedList<Point> Coordinates;
        public TTPointsEngine()
        {
            Coordinates = new LinkedList<Point>();
        }

        public void TryCoordinates(Point coordinate)
        {
            Coordinates.AddFirst(coordinate);
        }

        public Direction DetermineDirectionOfBall(Coordinates previousPosition, Coordinates currentPosition)
        {
            if (previousPosition.X < currentPosition.X && previousPosition.Y < currentPosition.Y)
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

        public PlayStatus DetermineEndOfPlay(Coordinates currentPosition)
        {
            if(currentPosition.X <= 10 && currentPosition.Y <= 150 || currentPosition.X >= 400 && currentPosition.Y <= 150)
            {
                return PlayStatus.OverTable;
            }
            else if (currentPosition.X <= 10 && currentPosition.Y >= 150 || currentPosition.X >= 400 && currentPosition.Y >= 150)
            {
                return PlayStatus.UnderTable;
            }
            else if (currentPosition.X <= 300 && currentPosition.Y >= 150 || currentPosition.X >= 300 && currentPosition.Y >= 150)
            {
                return PlayStatus.SideOfTable;
            }
 
            return PlayStatus.Unknown;
           
        }

        
    }
}
