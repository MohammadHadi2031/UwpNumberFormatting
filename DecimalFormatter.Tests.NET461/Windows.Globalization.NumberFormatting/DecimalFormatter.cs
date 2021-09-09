using System;
using System.Globalization;

namespace Windows.Globalization.NumberFormatting
{
    public partial class DecimalFormatter :
        global::Windows.Globalization.NumberFormatting.INumberFormatterOptions,
        global::Windows.Globalization.NumberFormatting.INumberFormatter,
        global::Windows.Globalization.NumberFormatting.INumberFormatter2,
        global::Windows.Globalization.NumberFormatting.INumberParser,
        global::Windows.Globalization.NumberFormatting.ISignificantDigitsOption,
        global::Windows.Globalization.NumberFormatting.INumberRounderOption,
        global::Windows.Globalization.NumberFormatting.ISignedZeroOption
    {
        const string minusSign = "-";

        public bool IsDecimalPointAlwaysDisplayed
        {
            get;
            set;
        }

        public int IntegerDigits
        {
            get;
            set;
        } = 1;

        public bool IsGrouped
        {
            get;
            set;
        }

#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
        [global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
        public string NumeralSystem
        {
            get;
            set;
        }
#endif

        public int FractionDigits
        {
            get;
            set;
        } = 2;

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

        public global::Windows.Globalization.NumberFormatting.INumberRounder NumberRounder
        {
            get;
            set;
        }

        public bool IsZeroSigned
        {
            get;
            set;
        }

        public int SignificantDigits
        {
            get;
            set;
        } = 0;

#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
        [global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
        public DecimalFormatter(global::System.Collections.Generic.IEnumerable<string> languages, string geographicRegion)
        {
            global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.Globalization.NumberFormatting.DecimalFormatter", "DecimalFormatter.DecimalFormatter(IEnumerable<string> languages, string geographicRegion)");
        }
#endif

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
            const string numberDecimalSeparator = ".";
            

            if (NumberRounder != null)
            {
                value = NumberRounder.RoundDouble(value);
            }

            bool isNegative = BitConverter.DoubleToInt64Bits(value) < 0;

            if (value == 0d &&
                IntegerDigits == 0 &&
                FractionDigits == 0)
            {
                if (isNegative)
                    return minusSign + "0";
                else
                    return "0";
            }

            var integerPart = (int)Math.Truncate(value);

            bool addMinusSign = isNegative && value == 0;

            var integerPartLen = integerPart.GetLength();
            var fractionDigit = Math.Max(FractionDigits, SignificantDigits - integerPartLen);
            var rounded = Math.Round(value, fractionDigit, MidpointRounding.AwayFromZero);
            var needFormatting = value == rounded;
            // string.Format(value, "0.00#######") is a way to format # must be sufficient.
            var formattedFractionPart = needFormatting ? value.ToString($"F{fractionDigit}") : value.ToString();
            var indexOfDecimalSeperator = formattedFractionPart.LastIndexOf(numberDecimalSeparator);

            if (indexOfDecimalSeperator == -1)
            {
                formattedFractionPart = string.Empty;
            }
            else
            {
                formattedFractionPart = formattedFractionPart.Substring(indexOfDecimalSeperator);
            }

            var formattedIntegerPart = string.Empty;

            if (integerPart == 0 &&
                IntegerDigits == 0)
            {
                formattedIntegerPart = string.Empty;
            }
            else if (IsGrouped)
            {
                var zeros = "";
                for (int i = 0; i < IntegerDigits - 1; i++)
                {
                    zeros += "0";
                }
                formattedIntegerPart = integerPart.ToString(zeros + ",0");
            }
            else
            {
                formattedIntegerPart = integerPart.ToString($"D{IntegerDigits}");
            }

            var formatted = formattedIntegerPart + formattedFractionPart;

            if (IsDecimalPointAlwaysDisplayed &&
                formattedFractionPart == string.Empty)
            {
                formatted += numberDecimalSeparator;
            }

            if (addMinusSign)
            {
                formatted = minusSign + formatted;
            }

            return formatted;
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
                            return null;
                        }

                        break;
                    }
                    else if (Index - preIndex != groupSize)
                    {
                        return null;
                    }

                    preIndex = Index;
                }
            }

            var value = double.Parse(text, numberFormat);

            if (value == 0 &&
                text.Contains(minusSign))
            {
                return -0d;
            }

            return value;
        }
    }
}
