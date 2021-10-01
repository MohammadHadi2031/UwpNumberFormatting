using System;
using System.Globalization;

namespace Windows.Globalization.NumberFormatting
{
	public partial class DecimalFormatter : INumberFormatterOptions, INumberFormatter, INumberFormatter2, INumberParser, ISignificantDigitsOption, INumberRounderOption, ISignedZeroOption
	{
		private NumeralSystemTranslator _translator = new NumeralSystemTranslator();

		public bool IsDecimalPointAlwaysDisplayed { get; set; }

		public int IntegerDigits { get; set; } = 1;

		public bool IsGrouped { get; set; }

		public string NumeralSystem
		{
			get => _translator.NumeralSystem;
			set => _translator.NumeralSystem = value;
		}

		public int FractionDigits { get; set; } = 2;

#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public string GeographicRegion
		{
			get;
		}
#endif

#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public global::System.Collections.Generic.IReadOnlyList<string> Languages
		{
			get;
		}
#endif

#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public string ResolvedGeographicRegion
		{
			get;
		}
#endif

#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public string ResolvedLanguage
		{
			get;
		}
#endif

		public INumberRounder NumberRounder { get; set; }

		public bool IsZeroSigned { get; set; }

		public int SignificantDigits { get; set; } = 0;

		public DecimalFormatter()
		{

		}

#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public string Format(long value)
		{
			throw new global::System.NotImplementedException("The member string DecimalFormatter.Format(long value) is not implemented in Uno.");
		}
#endif

#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public string Format(ulong value)
		{
			throw new global::System.NotImplementedException("The member string DecimalFormatter.Format(ulong value) is not implemented in Uno.");
		}
#endif

#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public string Format(double value)
		{
			return FormatDouble(value);
		}
#endif

#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public string FormatInt(long value)
		{
			throw new global::System.NotImplementedException("The member string DecimalFormatter.FormatInt(long value) is not implemented in Uno.");
		}
#endif

#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public string FormatUInt(ulong value)
		{
			throw new global::System.NotImplementedException("The member string DecimalFormatter.FormatUInt(ulong value) is not implemented in Uno.");
		}
#endif

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

			if (NumberRounder != null)
			{
				value = NumberRounder.RoundDouble(value);
			}

			bool isNegative = BitConverter.DoubleToInt64Bits(value) < 0;

			if (value == 0d &&
				IntegerDigits == 0 &&
				FractionDigits == 0)
			{
				if (isNegative && IsZeroSigned)
				{
					var r = CultureInfo.InvariantCulture.NumberFormat.NegativeSign + "0";
					return _translator.TranslateNumerals(r);
				}
				else
				{
					return _translator.TranslateNumerals("0");
				}
			}

			bool addMinusSign = isNegative && value == 0;

			var formattedFractionPart = FormatFractionPart(value);
			var formattedIntegerPart = FormatIntegerPart(value);
			var formatted = formattedIntegerPart + formattedFractionPart;

			if (IsDecimalPointAlwaysDisplayed &&
				formattedFractionPart == string.Empty)
			{
				formatted += CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator;
			}

			if (addMinusSign && IsZeroSigned)
			{
				formatted = CultureInfo.InvariantCulture.NumberFormat.NegativeSign + formatted;
			}

			formatted = _translator.TranslateNumerals(formatted);
			return formatted;
		}

		private string FormatIntegerPart(double value)
		{
			var integerPart = (int)Math.Truncate(value);
			var formattedIntegerPart = string.Empty;

			if (integerPart == 0 &&
				IntegerDigits == 0)
			{
				return string.Empty;
			}
			else if (IsGrouped)
			{
				var zeros = "";
				for (int i = 0; i < IntegerDigits - 1; i++)
				{
					zeros += "0";
				}
				return integerPart.ToString(zeros + ",0", CultureInfo.InvariantCulture);
			}
			else
			{
				return integerPart.ToString($"D{IntegerDigits}", CultureInfo.InvariantCulture);
			}
		}

		private string FormatFractionPart(double value)
		{
			var numberDecimalSeparator = CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator;

			var integerPart = (int)Math.Truncate(value);
			var integerPartLen = integerPart.GetLength();
			var fractionDigits = Math.Max(FractionDigits, SignificantDigits - integerPartLen);
			var rounded = Math.Round(value, fractionDigits, MidpointRounding.AwayFromZero);
			var needZeros = value == rounded;
			var formattedFractionPart = needZeros ? value.ToString($"F{fractionDigits}", CultureInfo.InvariantCulture) : value.ToString(CultureInfo.InvariantCulture);
			var indexOfDecimalSeperator = formattedFractionPart.LastIndexOf(numberDecimalSeparator);

			if (indexOfDecimalSeperator == -1)
			{
				formattedFractionPart = string.Empty;
			}
			else
			{
				formattedFractionPart = formattedFractionPart.Substring(indexOfDecimalSeperator);
			}

			return formattedFractionPart;
		}

#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public long? ParseInt(string text)
		{
			throw new global::System.NotImplementedException("The member long? DecimalFormatter.ParseInt(string text) is not implemented in Uno.");
		}
#endif
#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public ulong? ParseUInt(string text)
		{
			throw new global::System.NotImplementedException("The member ulong? DecimalFormatter.ParseUInt(string text) is not implemented in Uno.");
		}
#endif
		public double? ParseDouble(string text)
		{
			text = _translator.TranslateBackNumerals(text);

			if (HasInvalidGroupSize(text))
			{
				return null;
			}

			if (!double.TryParse(text,
				NumberStyles.Float | NumberStyles.AllowThousands,
				CultureInfo.InvariantCulture, out double value))
			{
				return null;
			}

			if (value == 0 &&
				text.Contains(CultureInfo.InvariantCulture.NumberFormat.NegativeSign))
			{
				return -0d;
			}

			return value;
		}

		private bool HasInvalidGroupSize(string text)
		{
			var numberFormat = CultureInfo.InvariantCulture.NumberFormat;
			var decimalSeperatorIndex = text.LastIndexOf(numberFormat.NumberDecimalSeparator);
			var groupSize = numberFormat.NumberGroupSizes[0];
			var groupSeperatorLength = numberFormat.NumberGroupSeparator.Length;
			var groupSeperator = numberFormat.NumberGroupSeparator;

			var preIndex = text.IndexOf(groupSeperator);
			var Index = -1;

			if (preIndex != -1)
			{
				while (preIndex + groupSeperatorLength < text.Length)
				{
					Index = text.IndexOf(groupSeperator, preIndex + groupSeperatorLength);

					if (Index == -1)
					{
						if (decimalSeperatorIndex - preIndex - groupSeperatorLength != groupSize)
						{
							return true;
						}

						break;
					}
					else if (Index - preIndex != groupSize)
					{
						return true;
					}

					preIndex = Index;
				}
			}

			return false;
		}
	}
}
