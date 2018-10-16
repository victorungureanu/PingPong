using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Common
{
    public class Configuration
    {
        public virtual int FrameWidth => 640;
        public virtual int FrameHeight => 640;

        public virtual double HueMin => 0;
        public virtual double HueMax => 32;

        public virtual double SaturationMin => 139;
        public virtual double SaturationMax => 212;

        public virtual double ValueMin => 182;
        public virtual double ValueMax => 256;

        public virtual int Erode => 3;
        public virtual int Dilate => 8;

        public virtual bool ShowDebugWindows => true;
        public bool UseMorphOperations => true;
    }
}
