using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoboWars.Arena.Tests
{
    [TestClass()]
    public class TerrainGridTests
    {
        ITerrainGrid _target;

        [TestInitialize]
        public void SetUp()
        {
            _target = new TerrainGrid(5, 5);
        }

        [TestMethod()]
        public void TestMoveToNorthShouldIncreaseY()
        {
            GridPoint originalPosition = new GridPoint(0, 0);

            var newPosition = _target.MoveFrom(originalPosition, CompassDirection.NORTH);

            Assert.IsTrue(newPosition.X == originalPosition.X);
            Assert.IsTrue(newPosition.Y == originalPosition.Y + 1);
        }

        [TestMethod()]
        public void TestMoveToNorthWhenAtEndOfGrid()
        {
            GridPoint originalPosition = new GridPoint(0, 4);

            var newPosition = _target.MoveFrom(originalPosition, CompassDirection.NORTH);

            Assert.IsTrue(newPosition.X == originalPosition.X);
            Assert.IsTrue(newPosition.Y == originalPosition.Y);
        }

        [TestMethod()]
        public void TestAdvanceSoutnShouldDecreaseY()
        {
            GridPoint originalPosition = new GridPoint(2, 2);

            var newPosition = _target.MoveFrom(originalPosition, CompassDirection.SOUTH);

            Assert.IsTrue(newPosition.X == originalPosition.X);
            Assert.IsTrue(newPosition.Y == originalPosition.Y - 1);
        }

        [TestMethod()]
        public void TestMoveToSouthWhenAtEndOfGrid()
        {
            GridPoint originalPosition = new GridPoint(0, 0);

            var newPosition = _target.MoveFrom(originalPosition, CompassDirection.SOUTH);

            Assert.IsTrue(newPosition.X == originalPosition.X);
            Assert.IsTrue(newPosition.Y == originalPosition.Y);
        }

        [TestMethod()]
        public void TestAdvanceEastShouldIncreaseX()
        {
            GridPoint originalPosition = new GridPoint(2, 2);

            var newPosition = _target.MoveFrom(originalPosition, CompassDirection.EAST);

            Assert.IsTrue(newPosition.X == originalPosition.X + 1);
            Assert.IsTrue(newPosition.Y == originalPosition.Y);
        }

        [TestMethod()]
        public void TestMoveToEastWhenAtEndOfGrid()
        {
            GridPoint originalPosition = new GridPoint(4, 0);

            var newPosition = _target.MoveFrom(originalPosition, CompassDirection.EAST);

            Assert.IsTrue(newPosition.X == originalPosition.X);
            Assert.IsTrue(newPosition.Y == originalPosition.Y);
        }

        [TestMethod()]
        public void TestAdvanceWestShouldDecreaseX()
        {
            GridPoint originalPosition = new GridPoint(2, 2);

            var newPosition = _target.MoveFrom(originalPosition, CompassDirection.WEST);

            Assert.IsTrue(newPosition.X == originalPosition.X - 1);
            Assert.IsTrue(newPosition.Y == originalPosition.Y);
        }

        [TestMethod()]
        public void TestMoveToWestWhenAtEndOfGrid()
        {
            GridPoint originalPosition = new GridPoint(0, 3);

            var newPosition = _target.MoveFrom(originalPosition, CompassDirection.WEST);

            Assert.IsTrue(newPosition.X == originalPosition.X);
            Assert.IsTrue(newPosition.Y == originalPosition.Y);
        }

        [TestMethod()]
        [DataRow(3, 5)]
        [DataRow(5, 3)]
        [DataRow(5, 5)]
        public void TestIsInTerrainLimitsWhenPointIsOutShouldReturnFalse(int x, int y)
        {
            var gridPoint = new GridPoint(x, y);

            var result = _target.IsInTerrainLimits(gridPoint);

            Assert.IsFalse(result);
        }

        [TestMethod()]
        [DataRow(3, 3)]
        [DataRow(0, 0)]
        public void TestIsInTerrainLimitsWhenPointIsINShouldReturnTrue(int x, int y)
        {
            var gridPoint = new GridPoint(x, y);

            var result = _target.IsInTerrainLimits(gridPoint);

            Assert.IsTrue(result);
        }
    }
}