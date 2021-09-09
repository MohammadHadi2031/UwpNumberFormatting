using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace TestStringFormat
{
    [TestClass]
    public class UnitTest1
    {
       
        [TestMethod]
        public void TestMethod1()
        {
            var a = double.Parse("12,34.5",
                CultureInfo.InvariantCulture.NumberFormat);
        }
    }
}
