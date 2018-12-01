using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RoboWars.Arena.Tests
{
    [TestClass]
    public class GridPointTest
    {
        GridPoint _gridPointInstance;

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestExceptionIsThrownWhenXisNegative()
        {
            try
            {
                _gridPointInstance = new GridPoint(-1, 0);
            }
            catch (Exception ex)
            {
                Assert.IsFalse(String.IsNullOrEmpty(ex.Message));
                throw;
            }

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestExceptionIsThrownWhenYisNegative()
        {
            try
            {
                _gridPointInstance = new GridPoint(0, -3);
            }
            catch (Exception ex)
            {
                Assert.IsFalse(String.IsNullOrEmpty(ex.Message));
                throw;
            }

        }
    }
}
