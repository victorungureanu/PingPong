using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using log4net;

namespace PingPong.Tracking
{
    public class VideoProcessor
    {
        private ILog log;

        public VideoProcessor(ILog log)
        {
            this.log = log;
        }

        public void Process(string filePath)
        {
            log.Info($"Started processing a file {filePath}");

            VideoCapture capture = new VideoCapture(filePath);
            if (!capture.IsOpened)
            {
                log.Fatal("Could not open video file");
                return;
            }

            ;
        }

    }
}
