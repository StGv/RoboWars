using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoboWars.Arena;

namespace RoboWars.Arena.Tests
{
    [TestClass]
    public class CompassTest
    {
        [TestMethod]
        [DataRow(CompassDirection.EAST, CompassDirection.SOUTH)]
        [DataRow(CompassDirection.SOUTH, CompassDirection.WEST)]
        [DataRow(CompassDirection.WEST, CompassDirection.NORTH)]
        [DataRow(CompassDirection.NORTH, CompassDirection.EAST)]
        public void TestToRight(CompassDirection originalRobotDirection, CompassDirection expectedRobotDirection)
        {
            var actual = originalRobotDirection.ToRight();
            Assert.IsTrue(actual == expectedRobotDirection);
        }

        [TestMethod]
        [DataRow(CompassDirection.EAST, CompassDirection.NORTH)]
        [DataRow(CompassDirection.SOUTH, CompassDirection.EAST)]
        [DataRow(CompassDirection.WEST, CompassDirection.SOUTH)]
        [DataRow(CompassDirection.NORTH, CompassDirection.WEST)]
        public void TestToLeft(CompassDirection originalRobotDirection, CompassDirection expectedRobotDirection)
        {
            var actual = originalRobotDirection.ToLeft();
            Assert.IsTrue(actual == expectedRobotDirection);
        }
    }
}
