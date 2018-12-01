using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RoboWars.Arena;

namespace RoboWars.Tests
{
    [TestClass]
    public class RobotTest
    {
        Mock<ITerrainGrid> terrainGrid;
        Robot robot; 

        [TestInitialize]
        public void SetUp()
        {
            terrainGrid = new Mock<ITerrainGrid>();
        }

        [TestCleanup]
        public void CleanUp()
        {
            robot = null;
        }

        [TestMethod]
        public void TestMoveForwardWhenFacingNorth()
        {
            GridPoint originalPosition = new GridPoint(0, 0);
            CompassDirection originalRobotDirection = CompassDirection.NORTH;
            terrainGrid.Setup(x => x.IsInTerrainLimits(originalPosition)).Returns(true);
            terrainGrid.Setup(x => x.MoveFrom(originalPosition, originalRobotDirection)).Returns(new GridPoint(0, 1));
            robot = new Robot(terrainGrid.Object, originalPosition, originalRobotDirection);

            robot.MoveForward();

            Assert.IsTrue(robot.CurrentGridPosition.X == originalPosition.X);
            Assert.IsTrue(robot.CurrentGridPosition.Y == originalPosition.Y + 1);
            Assert.IsTrue(robot.CurrentCompassOrientation == originalRobotDirection);
        }

        [TestMethod]
        public void TestMoveForwardWhenFacingEast()
        {
            GridPoint originalPosition = new GridPoint(2, 2);
            CompassDirection originalRobotDirection = CompassDirection.EAST;
            terrainGrid.Setup(x => x.IsInTerrainLimits(originalPosition)).Returns(true);
            terrainGrid.Setup(x => x.MoveFrom(originalPosition, originalRobotDirection)).Returns(new GridPoint(3, 2));
            robot = new Robot(terrainGrid.Object, originalPosition, originalRobotDirection);

            robot.MoveForward();

            Assert.IsTrue(robot.CurrentGridPosition.X == originalPosition.X + 1);
            Assert.IsTrue(robot.CurrentGridPosition.Y == originalPosition.Y);
            Assert.IsTrue(robot.CurrentCompassOrientation == originalRobotDirection);
        }

        [TestMethod]
        public void TestMoveForwardWhenFacingSouth()
        {
            GridPoint originalPosition = new GridPoint(2, 2);
            CompassDirection originalRobotDirection = CompassDirection.SOUTH;
            terrainGrid.Setup(x => x.IsInTerrainLimits(originalPosition)).Returns(true);
            terrainGrid.Setup(x => x.MoveFrom(originalPosition, originalRobotDirection)).Returns(new GridPoint(2, 1));
            robot = new Robot(terrainGrid.Object, originalPosition, originalRobotDirection);

            robot.MoveForward();

            Assert.IsTrue(robot.CurrentGridPosition.X == originalPosition.X);
            Assert.IsTrue(robot.CurrentGridPosition.Y == originalPosition.Y - 1);
            Assert.IsTrue(robot.CurrentCompassOrientation == originalRobotDirection);
        }

        [TestMethod]
        public void TestMoveForwardWhenFacingWest()
        {
            GridPoint originalPosition = new GridPoint(2, 2);
            CompassDirection originalRobotDirection = CompassDirection.WEST;
            terrainGrid.Setup(x => x.IsInTerrainLimits(originalPosition)).Returns(true);
            terrainGrid.Setup(x => x.MoveFrom(originalPosition, originalRobotDirection)).Returns(new GridPoint(1, 2));
            robot = new Robot(terrainGrid.Object, originalPosition, originalRobotDirection);

            robot.MoveForward();

            Assert.IsTrue(robot.CurrentGridPosition.X == originalPosition.X - 1);
            Assert.IsTrue(robot.CurrentGridPosition.Y == originalPosition.Y);
            Assert.IsTrue(robot.CurrentCompassOrientation == originalRobotDirection);
        }


        [TestMethod]
        [DataRow(CompassDirection.EAST, CompassDirection.SOUTH)]
        [DataRow(CompassDirection.SOUTH, CompassDirection.WEST)]
        [DataRow(CompassDirection.WEST, CompassDirection.NORTH)]
        [DataRow(CompassDirection.NORTH, CompassDirection.EAST)]
        public void TestTurnRight(CompassDirection originalRobotDirection, CompassDirection expectedRobotDirection)
        {
            GridPoint originalPosition = new GridPoint(2, 2);
            terrainGrid.Setup(x => x.IsInTerrainLimits(originalPosition)).Returns(true);
            robot = new Robot(terrainGrid.Object, originalPosition, originalRobotDirection);

            robot.TurnRight();

            Assert.IsTrue(robot.CurrentCompassOrientation == expectedRobotDirection);
            Assert.IsTrue(robot.CurrentGridPosition == originalPosition);
        }

        [TestMethod]
        [DataRow(CompassDirection.EAST, CompassDirection.NORTH)]
        [DataRow(CompassDirection.SOUTH, CompassDirection.EAST)]
        [DataRow(CompassDirection.WEST, CompassDirection.SOUTH)]
        [DataRow(CompassDirection.NORTH, CompassDirection.WEST)]
        public void TestTurnLeft(CompassDirection originalRobotDirection, CompassDirection expectedRobotDirection)
        {
            GridPoint originalPosition = new GridPoint(2, 2);
            terrainGrid.Setup(x => x.IsInTerrainLimits(originalPosition)).Returns(true);
            robot = new Robot(terrainGrid.Object, originalPosition, originalRobotDirection);

            robot.TurnLeft();

            Assert.IsTrue(robot.CurrentCompassOrientation == expectedRobotDirection);
            Assert.IsTrue(robot.CurrentGridPosition == originalPosition);
        }
    }
}
