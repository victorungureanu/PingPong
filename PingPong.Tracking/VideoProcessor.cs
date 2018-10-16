using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using log4net;
using PingPong.Common;
using System;
using System.Drawing;

namespace PingPong.Tracking
{
    public interface IVideoProcessor
    {
        Mat CameraFeed { get; }
        Mat HSV { get; }
        Mat Thresold { get; }
        bool ShouldStop { get; set; }
        void Process(string filePath);


    }

    public class VideoProcessor : IVideoProcessor
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

        public Action<Point> BallDetected { private get; set; }

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

            ////TODO: why am I doing this? what happens if I don't?
            //capture.SetCaptureProperty(CapProp.FrameWidth, configuration.FrameWidth);
            //capture.SetCaptureProperty(CapProp.FrameHeight, configuration.FrameHeight);

            ProcessVideoCapture(capture);

        }

        private void ProcessVideoCapture(VideoCapture capture)
        {
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

                if (configuration.UseMorphOperations)
                {
                    ApplyMorphOps();
                }

                var ballPosition = GetFilteredObjectPosition(threshold);

                if (!ballPosition.IsEmpty)
                {
                    BallDetected?.Invoke(ballPosition);
                }

                if (configuration.ShowDebugWindows)
                {
                    if (!ballPosition.IsEmpty)
                    {
                        CvInvoke.Circle(cameraFeed, ballPosition, 20, new MCvScalar(0, 255, 0), 2);
                        CvInvoke.PutText(cameraFeed, $"{ballPosition.X},{ballPosition.Y}", new Point(ballPosition.X, ballPosition.Y + 30), FontFace.HersheyComplex, 1, new MCvScalar(0, 255, 0), 2);
                    }

                    ShowDebugWindows();
                }
            }
        }

        private Point GetFilteredObjectPosition(Mat threshold)
        {
            int x = 0, y = 0;

            using (var temp = new Mat())
            {
                threshold.CopyTo(temp);
                var largestContour = FindLargestContour(temp);
                if (largestContour != null)
                {
                    var moment = CvInvoke.Moments(largestContour);
                    x = (int)(moment.M10 / moment.M00);
                    y = (int)(moment.M01 / moment.M00);
                }
            }

            return new Point(x, y);
        }


        private VectorOfPoint FindLargestContour(IInputOutputArray cannyEdges)
        {
            int largest_contour_index = 0;
            double largest_area = 0;
            VectorOfPoint largestContour;

            using (Mat hierachy = new Mat())
            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {

                CvInvoke.FindContours(cannyEdges, contours, hierachy, RetrType.Tree, ChainApproxMethod.ChainApproxNone);

                if (contours.Size == 0)
                {
                    return null;
                }

                for (int i = 0; i < contours.Size; i++)
                {
                    MCvScalar color = new MCvScalar(0, 0, 255);

                    double a = CvInvoke.ContourArea(contours[i], false);  //  Find the area of contour
                    if (a > largest_area)
                    {
                        largest_area = a;
                        largest_contour_index = i;                //Store the index of largest contour
                    }
                }

                largestContour = new VectorOfPoint(contours[largest_contour_index].ToArray());
            }

            return largestContour;
        }


        private void ApplyMorphOps()
        {
            if (configuration.Erode > 0)
            {
                Mat erodeElement = CvInvoke.GetStructuringElement(ElementShape.Rectangle,
                    new System.Drawing.Size(configuration.Erode, configuration.Erode), new Point(-1, -1));

                CvInvoke.Erode(threshold, threshold, erodeElement, new Point(-1, -1), 2, BorderType.Constant,
                    new MCvScalar(double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue));
            }

            if (configuration.Dilate > 0)
            {
                Mat dilateElement = CvInvoke.GetStructuringElement(ElementShape.Rectangle,
                    new System.Drawing.Size(configuration.Dilate, configuration.Dilate), new Point(-1, -1));

                CvInvoke.Dilate(threshold, threshold, dilateElement, new Point(-1, -1), 2, BorderType.Constant,
                    new MCvScalar(double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue));
            }
        }

        private void ShowDebugWindows()
        {
            CvInvoke.Imshow("Original Image", cameraFeed);
            CvInvoke.Imshow("HSV Image", hsv);
            CvInvoke.Imshow("Threshold", threshold);

            CvInvoke.WaitKey(30);
        }

    }
}
