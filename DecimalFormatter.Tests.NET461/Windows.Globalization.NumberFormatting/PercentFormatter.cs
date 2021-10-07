using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Windows.Globalization.NumberFormatting
{
	public  partial class PercentFormatter : INumberFormatterOptions, INumberFormatter, INumberFormatter2, INumberParser, ISignificantDigitsOption, INumberRounderOption, ISignedZeroOption
	{
		private readonly DecimalFormatter _formatter;

		public PercentFormatter()
		{
			_formatter = new DecimalFormatter();
		}

		public bool IsDecimalPointAlwaysDisplayed { get => _formatter.IsDecimalPointAlwaysDisplayed; set => _formatter.IsDecimalPointAlwaysDisplayed = value; }

		public int IntegerDigits { get => _formatter.IntegerDigits; set => _formatter.IntegerDigits = value; }

		public bool IsGrouped { get => _formatter.IsGrouped; set => _formatter.IsGrouped = value; }

		public string NumeralSystem
		{
			get => _formatter.NumeralSystem;
			set => _formatter.NumeralSystem = value;
		}

		public IReadOnlyList<string> Languages => _formatter.Languages;

		public string ResolvedLanguage => _formatter.ResolvedLanguage;

		public int FractionDigits { get => _formatter.FractionDigits; set => _formatter.FractionDigits = value; }

		public INumberRounder NumberRounder { get => _formatter.NumberRounder; set => _formatter.NumberRounder = value; }

		public bool IsZeroSigned { get => _formatter.IsZeroSigned; set => _formatter.IsZeroSigned = value; }

		public int SignificantDigits { get => _formatter.SignificantDigits; set => _formatter.SignificantDigits = value; }

		public string Format(double value) => FormatDouble(value);

		public string FormatDouble(double value)
		{
			if (double.IsNaN(value))
			{
				return "NaN";
			}

			if (double.IsPositiveInfinity(value))
			{
				return "∞";
			}

			if (double.IsNegativeInfinity(value))
			{
				return "-∞";
			}

			var symbol = "%";
			if (NumeralSystem.Equals("ArabExt", StringComparison.Ordinal) ||
				NumeralSystem.Equals("Arab", StringComparison.Ordinal))
            {
				symbol = "\u066a";
            }

			return _formatter.FormatDouble(value * 100) + symbol;	
		}


		public double? ParseDouble(string text)
		{
			return _formatter.ParseDouble(text);
		}
	}
}
