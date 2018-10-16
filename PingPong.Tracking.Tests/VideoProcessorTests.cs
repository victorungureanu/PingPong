using System;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace PingPong.Tracking.Tests
{
    [TestClass]
    public class VideoProcessorTests
    {
        private VideoProcessor processor;
        private Mock<ILog> logMock;


        [TestInitialize]
        public void Setup()
        {
            logMock = new Mock<ILog>();
            processor = new VideoProcessor(logMock.Object);
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
