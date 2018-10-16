using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PointsEngine;

namespace BounceDetection.Tests
{
    [TestClass()]
    public class BounceDetectionTests
    {
        [TestMethod()]
        public void HasBouncedTest()
        {
            var bounceService = new BounceDetection();
            List<Direction> directions = new List<Direction>()
            {
                Direction.SouthEast,
                Direction.SouthEast,
                Direction.SouthEast
            };

            var result = bounceService.HasTheDirectionChanged(directions);
            Assert.IsFalse(result);
        }
    }
}