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
            //var cultureInfo = new CultureInfo("zh-cmn-Hans");
            //var DisplayName = cultureInfo.DisplayName;
            //var NativeName = cultureInfo.NativeName;
            var regionInfo = new RegionInfo("ir");
            var ss = 0.ToString($"D0", CultureInfo.InvariantCulture);
        }
    }
}
