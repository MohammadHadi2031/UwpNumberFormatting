using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace TestStringFormat
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow(1.25, 1.2)]
        [DataRow(1.27, 1.3)]
        [DataRow(1.23, 1.2)]
        [DataRow(-1.25, -1.2)]
        [DataRow(-1.27, -1.3)]
        [DataRow(-1.23, -1.2)]
        [DataRow(1.35, 1.4)]
        [DataRow(1.37, 1.4)]
        [DataRow(1.33, 1.3)]
        [DataRow(-1.35, -1.4)]
        [DataRow(-1.37, -1.4)]
        [DataRow(-1.33, -1.3)]
        public void TestMethod1(double value, double expected)
        {
            var a = Math.Round(value, 1, MidpointRounding.ToEven);

            Assert.AreEqual(expected, a);
        }
    }
}
