using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PointsEngine;

namespace PointsEngineTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

        }

        [TestMethod]
        public void DetermineDirectionOfBall_WhenWeGet2Coordinates_GivesADirection()
        {
            var pointsEngine = new TTPointsEngine();

            Coordinates firstPoint = new Coordinates(3, 1);
            Coordinates secondPoint = new Coordinates(5, 4);

            var result = pointsEngine.DetermineDirectionOfBall(firstPoint, secondPoint);

            Assert.IsTrue(result.GetType() == typeof(Direction));
        }

        [TestMethod]
        public void DetermineDirectionOfBall_WhenBallTravelsSouthEast()
        {
            var pointsEngine = new TTPointsEngine();

            Coordinates previousPosition = new Coordinates(3, 1);
            Coordinates currentPosition = new Coordinates(5, 4);

            var result = pointsEngine.DetermineDirectionOfBall(previousPosition, currentPosition);

            Assert.AreEqual(Direction.SouthEast, result) ;

        }

        [TestMethod]
        public void DetermineDirectionOfBall_WhenBallTravelsSouth()
        {
            var pointsEngine = new TTPointsEngine();

            Coordinates previousPosition = new Coordinates(5, 1);
            Coordinates currentPosition = new Coordinates(5, 4);

            var result = pointsEngine.DetermineDirectionOfBall(previousPosition, currentPosition);

            Assert.AreEqual(Direction.South, result);
        }

        [TestMethod]
        public void DetermineDirectionOfBall_WhenBallTravelsSouthWest()
        {
            var pointsEngine = new TTPointsEngine();

            Coordinates previousPosition = new Coordinates(5, 1);
            Coordinates currentPosition = new Coordinates(3, 5);

            var result = pointsEngine.DetermineDirectionOfBall(previousPosition, currentPosition);

            Assert.AreEqual(Direction.SouthWest, result);
        }

        [TestMethod]
        public void DetermineDirectionOfBall_WhenBallTravelsEast()
        {
            var pointsEngine = new TTPointsEngine();

            Coordinates previousPosition = new Coordinates(3, 5);
            Coordinates currentPosition = new Coordinates(5, 5);

            var result = pointsEngine.DetermineDirectionOfBall(previousPosition, currentPosition);

            Assert.AreEqual(Direction.East, result);
        }

        [TestMethod]
        public void DetermineDirectionOfBall_WhenBallTravelsNorthEast()
        {
            var pointsEngine = new TTPointsEngine();

            Coordinates previousPosition = new Coordinates(3, 6);
            Coordinates currentPosition = new Coordinates(5, 3);

            var result = pointsEngine.DetermineDirectionOfBall(previousPosition, currentPosition);

            Assert.AreEqual(Direction.NorthEast, result);
        }

        [TestMethod]
        public void DetermineDirectionOfBall_WhenBallTravelsNorth()
        {
            var pointsEngine = new TTPointsEngine();

            Coordinates previousPosition = new Coordinates(5, 6);
            Coordinates currentPosition = new Coordinates(5, 3);

            var result = pointsEngine.DetermineDirectionOfBall(previousPosition, currentPosition);

            Assert.AreEqual(Direction.North, result);
        }

        [TestMethod]
        public void DetermineDirectionOfBall_WhenBallTravelsNorthWest()
        {
            var pointsEngine = new TTPointsEngine();

            Coordinates previousPosition = new Coordinates(6, 6);
            Coordinates currentPosition = new Coordinates(5, 3);

            var result = pointsEngine.DetermineDirectionOfBall(previousPosition, currentPosition);

            Assert.AreEqual(Direction.NorthWest, result);
        }

        [TestMethod]
        public void DetermineDirectionOfBall_WhenBallTravelsWest()
        {
            var pointsEngine = new TTPointsEngine();

            Coordinates previousPosition = new Coordinates(6, 5);
            Coordinates currentPosition = new Coordinates(5, 5);

            var result = pointsEngine.DetermineDirectionOfBall(previousPosition, currentPosition);

            Assert.AreEqual(Direction.West, result);
        }
    }
}
