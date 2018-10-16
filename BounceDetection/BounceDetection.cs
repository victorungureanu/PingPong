using System.Collections.Generic;
using System.Linq;
using PointsEngine;

namespace BounceDetection
{
    public class BounceDetection
    {
        public BounceDirection.Direction GetDirectionsFromCoordinates(List<Coordinates> coordinates)
        {
            List<Direction> directionsToProcess = new List<Direction>();
            TTPointsEngine pointsEngine = new TTPointsEngine();

            for (int i = 0; i < coordinates.Count; i++)
            {
                directionsToProcess.Add(pointsEngine.DetermineDirectionOfBall(coordinates[i], coordinates[i + 1]));
            }
            return BounceDirection(directionsToProcess);
        }

        public BounceDirection.Direction BounceDirection(List<Direction> directions)
        {
            //Check if the direction has changed at all from the batched list of directions
            if (!HasTheDirectionChanged(directions))
            {

            }

            return global::BounceDetection.BounceDirection.Direction.Left;
        }

        
        public bool HasTheDirectionChanged(List<Direction> directions)
        {
            return (directions.Any(o => o != directions[0]));
        }
    }
}
