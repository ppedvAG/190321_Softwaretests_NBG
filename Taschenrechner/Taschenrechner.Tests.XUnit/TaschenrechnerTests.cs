using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Taschenrechner.Tests.XUnit
{
    public class TaschenrechnerTests
    {
        // Normalfall
        [Fact]
        [Trait(Category.XUnit, "")]
        public void Taschenrechner_Add_5_and_3_results_8()
        {
            // Arrange
            var tr = new Taschenrechner();

            // Act
            var result = tr.Add(5, 3);

            // Assert
            Assert.Equal(8, result);
        }
        // Normalfälle zusammengefasst
        [Theory]
        [Trait(Category.XUnit, "")]
        [InlineData(3, 5, 8)]
        [InlineData(5, 3, 8)]
        [InlineData(3, -5, -2)]
        [InlineData(-3, 5, 2)]
        [InlineData(0, 0, 0)]
        public void Taschenrechner_Add(int z1, int z2, int expected)
        {
            // Arrange
            var tr = new Taschenrechner();

            // Act
            var result = tr.Add(z1, z2);

            // Assert
            Assert.Equal(expected, result);
        }

        // Extremfälle
        [Fact]
        [Trait(Category.XUnit, "")]
        public void Taschenrechner_Add_MaxInt_and_1_throws_OverflowException()
        {
            var tr = new Taschenrechner();
            Assert.Throws<OverflowException>(() => tr.Add(Int32.MaxValue, 1));
        }
        [Fact]
        [Trait(Category.XUnit, "")]
        public void Taschenrechner_Add_MinInt_and_NEG1_throws_OverflowException()
        {
            var tr = new Taschenrechner();
            Assert.Throws<OverflowException>(() => tr.Add(Int32.MinValue, -1));
        }
        [Fact]
        [Trait(Category.XUnit, "")]
        public void Taschenrechner_Add_0_and_0_results_0()
        {
            var tr = new Taschenrechner();

            var result = tr.Add(0, 0);

            Assert.Equal(0, result);
        }
    }
}
