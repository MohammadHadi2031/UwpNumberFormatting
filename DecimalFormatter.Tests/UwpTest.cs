
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.Globalization.NumberFormatting;
using WS = Windows.Globalization.NumberFormatting;

namespace DecimalFormatter.Tests.UWP
{
    [TestClass]
    public class UwpTest
    {
        [DataTestMethod]
        [DataRow(1.5d, "1.50")]
        [DataRow(1.567d, "1.567")]
        [DataRow(1.5602d, "1.5602")]
        public void TestMethod1(double value, string expected)
        {
            WS.DecimalFormatter df = new WS.DecimalFormatter();
            df.FractionDigits = 2;
            df.IntegerDigits = 1;

            var formatted = df.FormatDouble(value);
            Assert.AreEqual(expected, formatted);
        }

        [DataTestMethod]
        [DataRow(1234, 2, 0, true, "1,234")]
        [DataRow(1234, 2, 0, false, "1234")]
        [DataRow(1234, 6, 0, false, "001234")]
        [DataRow(1234, 6, 0, true, "001,234")]
        [DataRow(1234.56, 2, 2, true, "1,234.56")]
        [DataRow(1234.567, 2, 2, false, "1234.567")]
        [DataRow(1234.5, 6, 2, false, "001234.50")]
        [DataRow(1234.0, 6, 2, true, "001,234.00")]
        [DataRow(1234.0, 6, 0, true, "001,234")]
        [DataRow(0.52, 0, 2, false, ".52")]
        public void TestFormat(double value, int integerDigits, int fractionDigits, bool isGrouped, string expected)
        {
            WS.DecimalFormatter df = new WS.DecimalFormatter();
            df.FractionDigits = fractionDigits;
            df.IntegerDigits = integerDigits;
            df.IsGrouped = isGrouped;


            var formatted = df.FormatDouble(value);
            Assert.AreEqual(expected, formatted);
        }

        //[TestMethod]
        public void Test_IsGrouped()
        {
            WS.DecimalFormatter df = new WS.DecimalFormatter();
            df.IsGrouped = true;

            var formatted = df.FormatDouble(1234.567d);
            Console.WriteLine(formatted);
        }

        [DataTestMethod]
        [DataRow(0d, 0, 0, true, "0")]
        [DataRow(-0d, 0, 0, true, "-0")]
        [DataRow(0d, 0, 2, true, ".00")]
        [DataRow(-0d, 0, 2, true, "-.00")]
        [DataRow(0d, 2, 0, true, "00")]
        [DataRow(-0d, 2, 0, true, "-00")]
        [DataRow(0d, 3, 1, true, "000.0")]
        [DataRow(-0d, 3, 1, true, "-000.0")]
        public void Test_IsZeroSigned(double value, int integerDigits, int fractionDigits, bool isZeroSigned, string expected)
        {
            WS.DecimalFormatter df = new WS.DecimalFormatter();
            df.IsZeroSigned = isZeroSigned;
            df.IntegerDigits = integerDigits;
            df.FractionDigits = fractionDigits;

            var formatted = df.FormatDouble(value);
            Assert.AreEqual(expected, formatted);
        }

        [DataTestMethod]
        [DataRow(1d, "1.")]
        public void Test_IsDecimalPointerAlwaysDisplayed(double value, string expected)
        {
            WS.DecimalFormatter df = new WS.DecimalFormatter();
            df.IsDecimalPointAlwaysDisplayed = true;
            df.FractionDigits = 0;
            df.IntegerDigits = 0;

            var formatted = df.FormatDouble(value);
            Assert.AreEqual(expected, formatted);
        }

        [DataTestMethod]
        [DataRow(123.4567d, 5, 1, 2, "123.4567")]
        [DataRow(123.4567d, 10, 1, 2, "123.4567000")]
        [DataRow(123.4567d, 2, 1, 2, "123.4567")]
        [DataRow(12.3d, 4, 1, 2, "12.30")]
        [DataRow(12.3d, 4, 1, 0, "12.30")]
        public void Test_SignificantDigits(double value, int significantDigits, int integerDigits, int fractionDigits, string expected)
        {
            WS.DecimalFormatter df = new WS.DecimalFormatter();
            df.SignificantDigits = significantDigits;
            df.IntegerDigits = integerDigits;
            df.FractionDigits = fractionDigits;

            var formatted = df.FormatDouble(value);
            Assert.AreEqual(expected, formatted);
        }

        [TestMethod]
        public void Test_InitValues()
        {
            WS.DecimalFormatter df = new WS.DecimalFormatter();

            /*
                FractionDigits	2	int
             	GeographicRegion	"US"	string
		        IntegerDigits	1	int
		        IsDecimalPointAlwaysDisplayed	false	bool
		        IsGrouped	false	bool
 		        IsZeroSigned	false	bool
                NumberRounder	null	Windows.Globalization.NumberFormatting.INumberRounder
		        NumeralSystem	"Latn"	string
		        ResolvedGeographicRegion	"ZZ"	string
		        ResolvedLanguage	"en-US"	string
		        SignificantDigits	0	int

             */
        }

        [DataTestMethod]
        [DataRow("1.2", false, 1.2)]
        [DataRow("1.20", false, 1.2)]
        [DataRow("1234.2", true, 1234.2)]
        [DataRow("1,234.2", true, 1234.2)]
        [DataRow("12,34.2", true, null)]
        [DataRow("12,34.2", false, null)]
        [DataRow("0", false, 0d)]
        public void When_ParseDouble(string value, bool isGrouped, double? expected)
        {
            WS.DecimalFormatter df = new WS.DecimalFormatter();
            df.FractionDigits = 2;
            df.IsGrouped = isGrouped;

            var actual = df.ParseDouble(value);
            
            if (actual.HasValue)
            {
                bool isNegative = BitConverter.DoubleToInt64Bits(actual.Value) < 0;
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_ParseDoubleMinusZero()
        {
            WS.DecimalFormatter df = new WS.DecimalFormatter();
            var actual = df.ParseDouble("-0");
            bool isNegative = false;

            if (actual.HasValue)
            {
                isNegative = BitConverter.DoubleToInt64Bits(actual.Value) < 0;
            }

            Assert.AreEqual(true, isNegative);
        }

    }
}
