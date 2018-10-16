using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsEngine
{
    public class Coordinates
    {
        private double _x;
        private double _y;

        public Coordinates(double x, double y)
        {
            this._x = x;
            this._y = y;
        }

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        //public Coordinates(double x, double y)
        //{
        //    this._x = x;
        //    this._y = y;
        //}

        public override string ToString()
        {
            return String.Format("{0},{1}", this.X, this.Y);
        }
    }
}
