using System;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using PingPong.Common;
using PingPong.Tracking;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // application setup
            XmlConfigurator.Configure();
            ILog log = LogManager.GetLogger("app");
            var config = new Configuration();

            // the magic
            VideoProcessor videoProcessor = new VideoProcessor(log, config);


            var processingTask = Task.Run(() => { videoProcessor.Process(@"C:\hackathon\input\video4.mov");}) ;


            Console.ReadKey(true);

            videoProcessor.ShouldStop = true;

            Task.WaitAll(processingTask);
        }
    }
}
