using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PingPong.Common;

namespace PingPong.Tracking.Tests
{
    [TestClass]
    public class VideoProcessorTests
    {
        private VideoProcessor processor;
        private Mock<ILog> logMock;
        private Mock<Configuration> configMock;


        [TestInitialize]
        public void Setup()
        {
            logMock = new Mock<ILog>();
            configMock = new Mock<Configuration>();

            processor = new VideoProcessor(logMock.Object, configMock.Object);
        }

        [TestMethod]
        public void TestMethod1()
        {
        }


        [TestCleanup]
        public void TearDown()
        {

        }
    }
}
