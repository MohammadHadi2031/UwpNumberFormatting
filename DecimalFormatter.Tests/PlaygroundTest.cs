using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Globalization.NumberFormatting;

namespace DecimalFormatterTests.UWP
{
    [TestClass]
    public class PlaygroundTest
    {
        [TestMethod]
        public void Test()
        {
            var formatter = new DecimalFormatter(new string[] {"en-US", "fa-IR"}, "ir");
            var actual = formatter.FormatDouble(1.5);
        }

        [TestMethod]
        public void Test2()
        {
            var formatter = new CurrencyFormatter("USD");
            formatter.Mode = CurrencyFormatterMode.UseCurrencyCode;

            var positive = formatter.FormatDouble(1.5);
            var negative = formatter.FormatDouble(-1.5);

            var d = formatter.ParseDouble("(USD ۱)");
        }

        [TestMethod]
        public void Test3()
        {
            var formatter = new CurrencyFormatter("USD");
            var positive = formatter.FormatDouble(1.5);
            var negative = formatter.FormatDouble(-1.5);

            var d = formatter.ParseDouble("($1.1)");
        }

        [TestMethod]
        public void Test4()
        {
            var formatter = new PercentFormatter();

            var positive = formatter.FormatDouble(1.5);
            var negative = formatter.FormatDouble(-1.5);
        }

        [TestMethod]
        public void Test5()
        {
            var formatter = new PermilleFormatter();

            var positive = formatter.FormatDouble(1.5);
            var negative = formatter.FormatDouble(-1.5);
        }
    }
}
