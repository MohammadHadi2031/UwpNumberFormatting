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
    public class Given_IncrementNumberRounder
    {
        [TestMethod]
        public void Should_Throw_When_RoundingAlgorithm_Is_None()
        {
            IncrementNumberRounder rounder = new IncrementNumberRounder();
            Assert.ThrowsException<ArgumentException>(() => rounder.RoundingAlgorithm = RoundingAlgorithm.None);
        }

        [DataTestMethod]
        [DataRow(0.5, false)]
        [DataRow(0.4, true)]
        [DataRow(0.25, false)]
        [DataRow(0.27, true)]
        [DataRow(0.333333333333333, false)]
        [DataRow(0.33333333333333, true)]
        [DataRow(0.1666666666666666, false)]
        [DataRow(0.166666666666666, true)]
        [DataRow(0.00020881186051367718, false)] // inv(4789)
        [DataRow(0.0002088118605136772, true)]
        [DataRow(1 / 10000000001d, true)]
        [DataRow(0.00000000017927947438331678, false)] // inv(5577883377)
        [DataRow(0.0000000001792794743833166, true)]
        public void Should_Throw_When_Increment_Is_Invalid(double increment, bool shouldThrow)
        {
            IncrementNumberRounder rounder = new IncrementNumberRounder();

            if (shouldThrow)
            {
                Assert.ThrowsException<ArgumentException>(() => rounder.Increment = increment);
            }
            else
            {
                rounder.Increment = increment;
            }
        }
    }
}
