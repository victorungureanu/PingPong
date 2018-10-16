using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using log4net;
using PingPong.Common;

namespace PingPong.Tracking
{
    public class VideoProcessor
    {
        private readonly ILog log;
        private readonly Configuration configuration;

        private readonly Mat cameraFeed = new Mat();
        private readonly Mat hsv = new Mat();
        private readonly Mat threshold = new Mat();

        public VideoProcessor(ILog log, Configuration configuration)
        {
            this.log = log;
            this.configuration = configuration;
        }

        public Mat CameraFeed => cameraFeed;
        public Mat HSV => hsv;
        public Mat Thresold => threshold;


        public bool ShouldStop { get; set; } = false;

        public void Process(string filePath)
        {
            log.Info($"Started processing a file {filePath}");

            VideoCapture capture = new VideoCapture(filePath);
            if (!capture.IsOpened)
            {
                log.Fatal("Could not open video file");
                return;
            }

            //TODO: why am I doing this? what happens if I don't?
            capture.SetCaptureProperty(CapProp.FrameWidth, configuration.FrameWidth);
            capture.SetCaptureProperty(CapProp.FrameHeight, configuration.FrameHeight);


            var frameNo = 0;

            while (!ShouldStop)//TODO: figure out when to stop
            {
                capture.Read(cameraFeed);

                CvInvoke.CvtColor(cameraFeed, hsv, ColorConversion.Bgr2Hsv);

                var minArray = new ScalarArray(new MCvScalar(
                    configuration.HueMin,
                    configuration.SaturationMin,
                    configuration.ValueMin));

                var maxArray = new ScalarArray(new MCvScalar(
                    configuration.HueMax,
                    configuration.SaturationMax,
                    configuration.ValueMax));

                CvInvoke.InRange(hsv, minArray, maxArray, threshold);

                if (configuration.ShowDebugWindows)
                {
                    CvInvoke.Imshow("Original Image", cameraFeed);
                    CvInvoke.Imshow("HSV Image", hsv);
                    CvInvoke.Imshow("Threshold", threshold);

                    CvInvoke.WaitKey(30);
                }
            }

        }
    }
}
