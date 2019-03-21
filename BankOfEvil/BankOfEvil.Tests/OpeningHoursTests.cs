using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfEvil.Tests
{
    [TestClass]
    public class OpeningHoursTests
    {
        [TestMethod]
        [DataRow(2019,3,18,12,12,12,true)] //Mo
        [DataRow(2019,3,18,19,0,0,false)] //Mo zu
        [DataRow(2019,3,19,12,12,12,true)] //Di
        [DataRow(2019,3,20,12,12,12,true)] //Mi
        [DataRow(2019,3,21,12,12,12,true)] //Do
        [DataRow(2019,3,22,12,12,12,true)] //Fr
        [DataRow(2019,3,23,12,12,12,true)] //Sa
        [DataRow(2019,3,19,5,12,12,false)] //Di zu
        [DataRow(2019,3,19,22,22,12,false)] //Di zu
        [DataRow(2019,3,23,5,14,12,false)] //Sa zu
        [DataRow(2019, 3, 23, 14, 0, 0, false)] //Sa zu

        public void OpeningHours_isOpen(int y, int mo,int d, int h, int mi, int s, bool expectedResult)
        {
            var oh = new OpeningHours();
            Assert.AreEqual(expectedResult, oh.IsOpen(new DateTime(y, mo, d, h, mi, s)));
        }
    }
}
