using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Taschenrechner.Tests.XUnit
{
    public class PersonTests
    {
        /* Anforderungen:
         * Referenzvergleich
         * Wertevergleich falls Referenzvergleich fehlschlägt
         */

        [Fact]
        [Trait("Personentests","")]
        public void Person_Equals_Parameter_is_null_Throws_ArgumentNullException()
        {
            var p1 = new Person();
            Assert.Throws<ArgumentNullException>(() => p1.Equals(null));
        }

        [Theory]
        [Trait("Personentests","")]
        [InlineData("wrong string")]
        [InlineData(12.5)]
        [InlineData(false)]
        public void Person_Equals_Parameter_has_wrong_type_returns_false(object wrongInput)
        {
            var p1 = new Person();
            Assert.False(p1.Equals(wrongInput));
        }

        [Fact]
        [Trait("Personentests","")]
        public void Person_Equals_Parameter_Has_Same_Referenece_returns_true()
        {
            var p1 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };
            var p2 = p1; // Referenzkopie

            Assert.True(p1.Equals(p2));
        }
        [Fact]
        [Trait("Personentests","")]
        public void Person_Equals_Parameter_Has_Same_Values_returns_true()
        {
            var p1 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };
            var p2 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };

            Assert.True(p1.Equals(p2));
        }
    }
}
