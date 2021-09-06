#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
using System;

namespace Windows.Globalization.NumberFormatting
{
    // #if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
    // [global::Uno.NotImplemented]
    // #endif
    public partial class DecimalFormatter :
        global::Windows.Globalization.NumberFormatting.INumberFormatterOptions,
        global::Windows.Globalization.NumberFormatting.INumberFormatter,
        global::Windows.Globalization.NumberFormatting.INumberFormatter2,
        global::Windows.Globalization.NumberFormatting.INumberParser,
        global::Windows.Globalization.NumberFormatting.ISignificantDigitsOption,
        global::Windows.Globalization.NumberFormatting.INumberRounderOption,
        global::Windows.Globalization.NumberFormatting.ISignedZeroOption
    {
        public bool IsDecimalPointAlwaysDisplayed
        {
            get;
            set;
        }

        public int IntegerDigits
        {
            get;
            set;
        }

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
        }

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
        }

#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
        [global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
        public DecimalFormatter(global::System.Collections.Generic.IEnumerable<string> languages, string geographicRegion)
        {
            global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.Globalization.NumberFormatting.DecimalFormatter", "DecimalFormatter.DecimalFormatter(IEnumerable<string> languages, string geographicRegion)");
        }
#endif

        // Forced skipping of method Windows.Globalization.NumberFormatting.DecimalFormatter.DecimalFormatter(System.Collections.Generic.IEnumerable<string>, string)
        public DecimalFormatter()
        {
            // global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.Globalization.NumberFormatting.DecimalFormatter", "DecimalFormatter.DecimalFormatter()");
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
            bool isNegative = BitConverter.DoubleToInt64Bits(value) < 0;
            string minusSign = "-";

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
            var fractionPart = value - (double)integerPart;
            fractionPart = Math.Round(fractionPart, 12);

            bool addMinusSign = isNegative && value == 0;



            var integerPartLen = GetIntegerLength(integerPart);
            var fractionDigit = Math.Max(FractionDigits, SignificantDigits - integerPartLen);
            const double eps = 0.000000000001;
            var rounded = Math.Round(fractionPart, fractionDigit);
            var needFormatting = Math.Abs(rounded - fractionPart) < eps;
            // string.Format(value, "0.00#######") is a way to format # must be sufficient.
            var formattedFractionPart = needFormatting ? fractionPart.ToString($"F{fractionDigit}") : fractionPart.ToString();
            formattedFractionPart = formattedFractionPart.Substring(1);

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
                const string numberDecimalSeparator = ".";
                formatted += numberDecimalSeparator;
            }

            if (addMinusSign)
            {
                formatted = minusSign + formatted;
            }

            return formatted;
        }

        private static int GetIntegerLength(int integerPart)
        {
            if (integerPart == 0)
                return 1;

            return (int)Math.Floor(Math.Log10(Math.Abs(integerPart))) + 1;
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
#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
        [global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
        public double? ParseDouble(string text)
        {
            throw new global::System.NotImplementedException("The member double? DecimalFormatter.ParseDouble(string text) is not implemented in Uno.");
        }
#endif
    }
}
