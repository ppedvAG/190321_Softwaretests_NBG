using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Taschenrechner.Tests
{
    [TestClass]
    public class TaschenrechnerTests
    {
        // Normalfall
        [TestMethod]
        [TestCategory(Category.MSTest)]
        public void Taschenrechner_Add_5_and_3_results_8()
        {
            // Arrange
            var tr = new Taschenrechner();

            // Act
            var result = tr.Add(5, 3);

            // Assert
            Assert.AreEqual(8, result);
        }
        // Normalfälle zusammengefasst
        [TestMethod]
        [TestCategory(Category.MSTest)]
        [DataRow(3,5,8)]
        [DataRow(5,3,8)]
        [DataRow(3,-5,-2)]
        [DataRow(-3,5,2)]
        [DataRow(0,0,0)]
        public void Taschenrechner_Add(int z1, int z2,int expected)
        {
            // Arrange
            var tr = new Taschenrechner();

            // Act
            var result = tr.Add(z1, z2);

            // Assert
            Assert.AreEqual(expected, result);
        }

        // Extremfälle
        [TestMethod]
        [TestCategory(Category.MSTest)]
        public void Taschenrechner_Add_MaxInt_and_1_throws_OverflowException()
        {
            var tr = new Taschenrechner();
            Assert.ThrowsException<OverflowException>(() => tr.Add(Int32.MaxValue, 1));
        }
        [TestMethod]
        [TestCategory(Category.MSTest)]
        public void Taschenrechner_Add_MinInt_and_NEG1_throws_OverflowException()
        {
            var tr = new Taschenrechner();
            Assert.ThrowsException<OverflowException>(() => tr.Add(Int32.MinValue, -1));
        }
        [TestMethod]
        [TestCategory(Category.MSTest)]
        public void Taschenrechner_Add_0_and_0_results_0()
        {
            var tr = new Taschenrechner();

            var result = tr.Add(0, 0);

            Assert.AreEqual(0, result);
        }
    }
}
