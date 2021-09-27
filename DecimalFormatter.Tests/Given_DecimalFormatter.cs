
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.Globalization.NumberFormatting;

namespace Uno.UI.Tests.Windows_Globalization
{
    [TestClass]
    public class Given_DecimalFormatter
    {
        [DataTestMethod]
        [DataRow(1.5d, 2, 1, "1.50")]
        [DataRow(1.567d, 2, 1, "1.567")]
        [DataRow(1.5602d, 2, 1, "1.5602")]
        [DataRow(0d, 0, 0, "0")]
        [DataRow(-0d, 0, 0, "0")]
        [DataRow(0d, 0, 2, ".00")]
        [DataRow(-0d, 0, 2, ".00")]
        [DataRow(0d, 2, 0, "00")]
        [DataRow(-0d, 2, 0, "00")]
        [DataRow(0d, 3, 1, "000.0")]
        [DataRow(-0d, 3, 1, "000.0")]
        public void TestMethod1(double value, int integerDigits, int fractionDigits, string expected)
        {
            DecimalFormatter df = new DecimalFormatter();
            df.IntegerDigits = integerDigits;
            df.FractionDigits = fractionDigits;

            var formatted = df.FormatDouble(value);
            Assert.AreEqual(expected, formatted);
        }

        [DataTestMethod]
        [DataRow(1234, 2, 0, "1,234")]
        [DataRow(1234, 6, 0, "001,234")]
        [DataRow(1234.56, 2, 2, "1,234.56")]
        [DataRow(1234.0, 6, 2, "001,234.00")]
        [DataRow(1234.0, 6, 0, "001,234")]
        public void When_FormatWithIsGroupSetTrue(double value, int integerDigits, int fractionDigits, string expected)
        {
            DecimalFormatter df = new DecimalFormatter();
            df.IntegerDigits = integerDigits;
            df.FractionDigits = fractionDigits;
            df.IsGrouped = true;

            var formatted = df.FormatDouble(value);
            Assert.AreEqual(expected, formatted);
        }

        [DataTestMethod]
        [DataRow(0d, 0, 0, "0")]
        [DataRow(-0d, 0, 0, "-0")]
        [DataRow(0d, 0, 2, ".00")]
        [DataRow(-0d, 0, 2, "-.00")]
        [DataRow(0d, 2, 0, "00")]
        [DataRow(-0d, 2, 0, "-00")]
        [DataRow(0d, 3, 1, "000.0")]
        [DataRow(-0d, 3, 1, "-000.0")]
        public void When_FormatWithIsZeroSignedSetTrue(double value, int integerDigits, int fractionDigits, string expected)
        {
            DecimalFormatter df = new DecimalFormatter();
            df.IntegerDigits = integerDigits;
            df.FractionDigits = fractionDigits;
            df.IsZeroSigned = true;

            var formatted = df.FormatDouble(value);
            Assert.AreEqual(expected, formatted);
        }

        [DataTestMethod]
        [DataRow(1d, "1.")]
        public void When_FormatWithIsDecimalPointerAlwaysDisplayedSetTrue(double value, string expected)
        {
            DecimalFormatter df = new DecimalFormatter();
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
        public void When_FormatWithSpecificSignificantDigits(double value, int significantDigits, int integerDigits, int fractionDigits, string expected)
        {
            DecimalFormatter df = new DecimalFormatter();
            df.SignificantDigits = significantDigits;
            df.IntegerDigits = integerDigits;
            df.FractionDigits = fractionDigits;

            var formatted = df.FormatDouble(value);
            Assert.AreEqual(expected, formatted);
        }

        [TestMethod]
        public void When_Initialize()
        {
            DecimalFormatter df = new DecimalFormatter();

            Assert.AreEqual(0, df.SignificantDigits);
            Assert.AreEqual(1, df.IntegerDigits);
            Assert.AreEqual(2, df.FractionDigits);
            Assert.AreEqual(false, df.IsGrouped);
            Assert.AreEqual(false, df.IsZeroSigned);
            Assert.AreEqual(false, df.IsDecimalPointAlwaysDisplayed);
            /*
                FractionDigits	2	int
             	GeographicRegion	"US"	string
		        IntegerDigits	1	int
		        IsDecimalPointAlwaysDisplayed	false	bool
		        IsGrouped	false	bool
 		        IsZeroSigned	false	bool
                NumberRounder	null	WindoGlobalization.NumberFormatting.INumberRounder
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
            DecimalFormatter df = new DecimalFormatter();
            df.FractionDigits = 2;
            df.IsGrouped = isGrouped;

            var actual = df.ParseDouble(value);
           
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void When_ParseDoubleMinusZero()
        {
            DecimalFormatter df = new DecimalFormatter();
            var actual = df.ParseDouble("-0");
            bool isNegative = false;

            if (actual.HasValue)
            {
                isNegative = BitConverter.DoubleToInt64Bits(actual.Value) < 0;
            }

            Assert.AreEqual(true, isNegative);
        }

        [TestMethod]
        public void When_ParseArabExtDouble()
        {
            DecimalFormatter df = new DecimalFormatter();
            df.NumeralSystem = "ArabExt";

            var translator = new NumeralSystemTranslator { NumeralSystem = "ArabExt" };
            var translated = translator.TranslateNumerals("1.2");

            var value = df.ParseDouble(translated);
            Assert.AreEqual(1.2d, value);
        }
    }
}
