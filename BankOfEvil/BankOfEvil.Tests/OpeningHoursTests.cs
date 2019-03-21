using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfEvil.Tests
{
    [TestClass]
    public class OpeningHoursTests
    {
        [TestMethod]
        [DataRow(2019, 3, 18, 12, 12, 12, true)] //Mo
        [DataRow(2019, 3, 18, 19, 0, 0, false)] //Mo zu
        [DataRow(2019, 3, 19, 12, 12, 12, true)] //Di
        [DataRow(2019, 3, 20, 12, 12, 12, true)] //Mi
        [DataRow(2019, 3, 21, 12, 12, 12, true)] //Do
        [DataRow(2019, 3, 22, 12, 12, 12, true)] //Fr
        [DataRow(2019, 3, 23, 12, 12, 12, true)] //Sa
        [DataRow(2019, 3, 19, 5, 12, 12, false)] //Di zu
        [DataRow(2019, 3, 19, 22, 22, 12, false)] //Di zu
        [DataRow(2019, 3, 23, 5, 14, 12, false)] //Sa zu
        [DataRow(2019, 3, 23, 14, 0, 0, false)] //Sa zu

        public void OpeningHours_isOpen(int y, int mo, int d, int h, int mi, int s, bool expectedResult)
        {
            var oh = new OpeningHours();
            Assert.AreEqual(expectedResult, oh.IsOpen(new DateTime(y, mo, d, h, mi, s)));
        }

        [TestMethod]
        public void OpeningHours_IsNowOpen()
        {
            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2019, 3, 23, 11, 0, 0);

                var oh = new OpeningHours();
                // Testen ob für Samstag um 11 uhr offen ist
                Assert.AreEqual(true, oh.IsNowOpen());

                // Lustige Sachen machen :)

                System.IO.Fakes.ShimFile.ExistsString = x => true; // Jede datei existiert
                Assert.IsTrue(File.Exists(@"7:\demo\\asdknasldn&/!%/%&("));
            }
            // Ab hier ist die Fake-methode nicht mehr gültig !
        }

        [TestMethod]
        public void Fakes_Test_BankAccount_Has_5_000_000_Balance()
        {
            var ba = new BankAccount();
            using (ShimsContext.Create())
            {
                BankOfEvil.Fakes.ShimBankAccount.AllInstances.BalanceGet = x => 5_000_000;

                Assert.AreEqual(5_000_000, ba.Balance);
            }
            Assert.AreEqual(0, ba.Balance);
        }
    }
}
