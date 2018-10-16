using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsEngine
{
    public interface ITTPointsEngine
    {
        Direction DetermineDirectionOfBall(Coordinates previousPosition, Coordinates currentPosition);
        PlayStatus DetermineEndOfPlay(Coordinates currentPosition);

        void TryCoordinates(Point point);
    }
}
