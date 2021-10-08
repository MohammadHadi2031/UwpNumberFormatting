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
    public class Given_CurrencyFormatter
    {
		private readonly string _currencyCode = "USD";

        [TestMethod]
        public void Test1()
        {
            var formatter = new CurrencyFormatter(_currencyCode);
            var actual = formatter.FormatDouble(1.5);
			var parsed = formatter.ParseDouble(actual);
        }

        [DataTestMethod]
        [DataRow(double.PositiveInfinity, "∞")]
        [DataRow(double.NegativeInfinity, "-∞")]
        [DataRow(double.NaN, "NaN")]
        public void When_FormatSpecialDouble(double value, string expected)
        {
            var formatter = new CurrencyFormatter(_currencyCode);
            var actual = formatter.FormatDouble(value);

            Assert.AreEqual(expected, actual);
        }

		[DataTestMethod]
		[DataRow(1.5d, 1, 2, "$1.50")]
		[DataRow(1.567d, 1, 2, "$1.567")]
		[DataRow(1.5602d, 1, 2, "$1.5602")]
		[DataRow(0d, 0, 0, "$0")]
		[DataRow(-0d, 0, 0, "$0")]
		[DataRow(0d, 0, 2, "$.00")]
		[DataRow(-0d, 0, 2, "$.00")]
		[DataRow(0d, 2, 0, "$00")]
		[DataRow(-0d, 2, 0, "$00")]
		[DataRow(0d, 3, 1, "$000.0")]
		[DataRow(-0d, 3, 1, "$000.0")]
		public void When_FormatDouble(double value, int integerDigits, int fractionDigits, string expected)
        {
            var formatter = new CurrencyFormatter(_currencyCode);
			formatter.IntegerDigits = integerDigits;
            formatter.FractionDigits = fractionDigits;

            var formatted = formatter.FormatDouble(value);
            Assert.AreEqual(expected, formatted);
        }

		[DataTestMethod]
		[DataRow(1234, 2, 0, "$1,234")]
		[DataRow(1234, 6, 0, "$001,234")]
		[DataRow(1234.56, 2, 2, "$1,234.56")]
		[DataRow(1234.0, 6, 2, "$001,234.00")]
		[DataRow(1234.0, 6, 0, "$001,234")]
		public void When_FormatDoubleWithIsGroupSetTrue(double value, int integerDigits, int fractionDigits, string expected)
		{
			var formatter = new CurrencyFormatter(_currencyCode);
			formatter.IntegerDigits = integerDigits;
			formatter.FractionDigits = fractionDigits;
			formatter.IsGrouped = true;

			var formatted = formatter.FormatDouble(value);
			Assert.AreEqual(expected, formatted);
		}

		[DataTestMethod]
		[DataRow(0, 0, "$-0")]
		[DataRow(0, 2, "$-.00")]
		[DataRow(2, 0, "$-00")]
		[DataRow(3, 1, "$-000.0")]
		public void When_FormatDoubleMinusZeroWithIsZeroSignedSetTrue(int integerDigits, int fractionDigits, string expected)
		{
			var formatter = new CurrencyFormatter(_currencyCode);
			formatter.IntegerDigits = integerDigits;
			formatter.FractionDigits = fractionDigits;
			formatter.IsZeroSigned = true;

			var formatted = formatter.FormatDouble(-0d);
			Assert.AreEqual(expected, formatted);
		}

		[DataTestMethod]
		[DataRow(0, 0, "$0")]
		[DataRow(0, 2, "$.00")]
		[DataRow(2, 0, "$00")]
		[DataRow(3, 1, "$000.0")]
		public void When_FormatDoubleZeroWithIsZeroSignedSetTrue(int integerDigits, int fractionDigits, string expected)
		{
			var formatter = new CurrencyFormatter(_currencyCode);
			formatter.IntegerDigits = integerDigits;
			formatter.FractionDigits = fractionDigits;
			formatter.IsZeroSigned = true;

			var formatted = formatter.FormatDouble(0d);
			Assert.AreEqual(expected, formatted);
		}

		[DataTestMethod]
		[DataRow(1d, "$1.")]
		public void When_FormatDoubleWithIsDecimalPointerAlwaysDisplayedSetTrue(double value, string expected)
		{
			var formatter = new CurrencyFormatter(_currencyCode);
			formatter.IsDecimalPointAlwaysDisplayed = true;
			formatter.FractionDigits = 0;
			formatter.IntegerDigits = 0;

			var formatted = formatter.FormatDouble(value);
			Assert.AreEqual(expected, formatted);
		}

		[DataTestMethod]
		[DataRow(123.4567d, 5, 1, 2, "$123.4567")]
		[DataRow(123.4567d, 10, 1, 2, "$123.4567000")]
		[DataRow(123.4567d, 2, 1, 2, "$123.4567")]
		[DataRow(12.3d, 4, 1, 2, "$12.30")]
		[DataRow(12.3d, 4, 1, 0, "$12.30")]
		public void When_FormatDoubleWithSpecificSignificantDigits(double value, int significantDigits, int integerDigits, int fractionDigits, string expected)
		{
			var formatter = new CurrencyFormatter(_currencyCode);
			formatter.SignificantDigits = significantDigits;
			formatter.IntegerDigits = integerDigits;
			formatter.FractionDigits = fractionDigits;

			var formatted = formatter.FormatDouble(value);
			Assert.AreEqual(expected, formatted);
		}

		[TestMethod]
		public void When_FormatDoubleUsingIncrementNumberRounder()
		{
			var formatter = new CurrencyFormatter(_currencyCode);
			IncrementNumberRounder rounder = new IncrementNumberRounder();
			rounder.Increment = 0.5;
			formatter.NumberRounder = rounder;
			var formatted = formatter.FormatDouble(1.8);

			Assert.AreEqual("$2.00", formatted);
		}

		[TestMethod]
		public void When_FormatDoubleUsingSignificantDigitsNumberRounder()
		{
			var formatter = new CurrencyFormatter(_currencyCode);
			SignificantDigitsNumberRounder rounder = new SignificantDigitsNumberRounder();
			rounder.SignificantDigits = 1;
			formatter.NumberRounder = rounder;
			var formatted = formatter.FormatDouble(1.8);

			Assert.AreEqual("$2.00", formatted);
		}

		[TestMethod]
		public void When_Initialize()
		{
			var formatter = new CurrencyFormatter(_currencyCode);

			Assert.AreEqual(0, formatter.SignificantDigits);
			Assert.AreEqual(1, formatter.IntegerDigits);
			Assert.AreEqual(2, formatter.FractionDigits);
			Assert.AreEqual(false, formatter.IsGrouped);
			Assert.AreEqual(false, formatter.IsZeroSigned);
			Assert.AreEqual(false, formatter.IsDecimalPointAlwaysDisplayed);
			Assert.AreEqual("en-US", formatter.ResolvedLanguage);
			Assert.IsNull(formatter.NumberRounder);
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
	}
}
