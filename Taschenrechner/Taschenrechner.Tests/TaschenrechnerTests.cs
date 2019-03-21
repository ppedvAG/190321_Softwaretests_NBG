using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Taschenrechner.Tests
{
    [TestClass]
    public class TaschenrechnerTests
    {
        // Normalfall
        [TestMethod]
        public void Taschenrechner_Add_5_and_3_results_8()
        {
            // Arrange
            var tr = new Taschenrechner();

            // Act
            var result = tr.Add(5, 3);

            // Assert
            Assert.AreEqual(8, result);
        }

        // Extremfälle
        [TestMethod]
        public void Taschenrechner_Add_MaxInt_and_1_throws_OverflowException()
        {
            var tr = new Taschenrechner();
            Assert.ThrowsException<OverflowException>(() => tr.Add(Int32.MaxValue, 1));
        }
        [TestMethod]
        public void Taschenrechner_Add_MinInt_and_NEG1_throws_OverflowException()
        {
            var tr = new Taschenrechner();
            Assert.ThrowsException<OverflowException>(() => tr.Add(Int32.MinValue, -1));
        }
        [TestMethod]
        public void Taschenrechner_Add_0_and_0_results_0()
        {
            var tr = new Taschenrechner();

            var result = tr.Add(0, 0);

            Assert.AreEqual(0, result);
        }
    }
}
