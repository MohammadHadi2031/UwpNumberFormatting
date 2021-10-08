using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
            var formatter = new CurrencyFormatter("IRR");
            var actual = formatter.FormatDouble(1.5);
        }

    }
}
