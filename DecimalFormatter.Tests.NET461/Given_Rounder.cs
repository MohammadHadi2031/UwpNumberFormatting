using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Globalization.NumberFormatting;

namespace Uno.UI.Tests.Windows_Globalization
{
    [TestClass]
    public class Given_Rounder
    {

        [TestMethod]
        public void When_UsingRoundMethod()
        {
            var rounded = Rounder.Round(4.48, 0, RoundingAlgorithm.RoundHalfAwayFromZero);
            Assert.AreEqual(4d, rounded);
        }

        [DataTestMethod]
        [DataRow(1.5, true)]
        [DataRow(0.5, true)]
        [DataRow(-0.5, true)]
        [DataRow(-12.5, true)]
        [DataRow(-4.5, true)]
        [DataRow(-4.50001, false)]
        public void When_Fraction_Is_Half_Then_Return_True(double value, bool expected)
        {
            Assert.AreEqual(expected, Rounder.IsFractionExactlyHalf(value));
        }
    }
}
