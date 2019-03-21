using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Taschenrechner.Tests
{
    [TestClass]
    public class TaschenrechnerTests
    {
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
    }
}
