using System;
using NUnit.Framework;

namespace Taschenrechner.Tests.NUnit
{
    [TestFixture]
    public class TaschenrechnerTests
    {
        // Normalfall
        [Test]
        [Category(Category.NUnit)]
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
        [Test]
        [Category(Category.NUnit)]
        [TestCase(3, 5, 8)]
        [TestCase(5, 3, 8)]
        [TestCase(3, -5, -2)]
        [TestCase(-3, 5, 2)]
        [TestCase(0, 0, 0)]
        public void Taschenrechner_Add(int z1, int z2, int expected)
        {
            // Arrange
            var tr = new Taschenrechner();

            // Act
            var result = tr.Add(z1, z2);

            // Assert
            Assert.AreEqual(expected, result);
        }

        // Extremfälle
        [Test]
        [Category(Category.NUnit)]
        public void Taschenrechner_Add_MaxInt_and_1_throws_OverflowException()
        {
            var tr = new Taschenrechner();
            Assert.Throws<OverflowException>(() => tr.Add(Int32.MaxValue, 1));
        }
        [Test]
        [Category(Category.NUnit)]
        public void Taschenrechner_Add_MinInt_and_NEG1_throws_OverflowException()
        {
            var tr = new Taschenrechner();
            Assert.Throws<OverflowException>(() => tr.Add(Int32.MinValue, -1));
        }
        [Test]
        [Category(Category.NUnit)]
        public void Taschenrechner_Add_0_and_0_results_0()
        {
            var tr = new Taschenrechner();

            var result = tr.Add(0, 0);

            Assert.AreEqual(0, result);
        }
    }
}
