using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using PingPong.Tracking;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            // application setup
            XmlConfigurator.Configure();
            ILog log = LogManager.GetLogger("app");

            // the magic
            VideoProcessor videoProcessor = new VideoProcessor(log);

            videoProcessor.Process(@"C:\hackathon\input\video4.mov");

        }

    }
}
