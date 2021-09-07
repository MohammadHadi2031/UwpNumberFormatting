#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
using System;
using System.Linq;

namespace Windows.Globalization.NumberFormatting
{
#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
    [global::Uno.NotImplemented]
#endif
    public partial class IncrementNumberRounder : global::Windows.Globalization.NumberFormatting.INumberRounder
    {
        private RoundingAlgorithm roundingAlgorithm = RoundingAlgorithm.RoundHalfUp;
        private double increment = 1d;

        public RoundingAlgorithm RoundingAlgorithm
        {
            get => roundingAlgorithm;
            set
            {
                if (value == RoundingAlgorithm.None)
                    throw new ArgumentException("The parameter is incorrect");

                roundingAlgorithm = value;
            }
        }

        public double Increment
        {
            get => increment;
            set
            {
                var exceptions = new double[]
                {
                    1E-11,
                    1E-12,
                    1E-13,
                    1E-14,
                    1E-15,
                    1E-16,
                    1E-17,
                    1E-18,
                    1E-19,
                    1E-20,
                };

                if (value <= 0)
                {
                    throw new ArgumentException("The parameter is incorrect");
                }
                else if (value <= 0.5)
                {
                    if (!exceptions.Any(e => e == value))
                    {
                        var inv = (1 / value);
                        var n = Math.Truncate(inv);
                        if (n < 2 || n > 10000000000)
                        {
                            throw new ArgumentException("The parameter is incorrect");
                        }

                        var modf = Math.Round(inv % 1, 14, MidpointRounding.AwayFromZero);
                        if (modf > 0)
                        {
                            throw new ArgumentException("The parameter is incorrect");
                        }
                    }
                }
                else if (value < 1)
                {
                    throw new ArgumentException("The parameter is incorrect");
                }
                else if (Math.Truncate(value) != value)
                {
                    throw new ArgumentException("The parameter is incorrect");
                }


                increment = value;
            }
        }

#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
        [global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
        public IncrementNumberRounder()
        {
            global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.Globalization.NumberFormatting.IncrementNumberRounder", "IncrementNumberRounder.IncrementNumberRounder()");
        }
#endif
        // Forced skipping of method Windows.Globalization.NumberFormatting.IncrementNumberRounder.IncrementNumberRounder()
#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
        [global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
        public int RoundInt32(int value)
        {
            throw new global::System.NotImplementedException("The member int IncrementNumberRounder.RoundInt32(int value) is not implemented in Uno.");
        }
#endif
#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
        [global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
        public uint RoundUInt32(uint value)
        {
            throw new global::System.NotImplementedException("The member uint IncrementNumberRounder.RoundUInt32(uint value) is not implemented in Uno.");
        }
#endif
#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
        [global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
        public long RoundInt64(long value)
        {
            throw new global::System.NotImplementedException("The member long IncrementNumberRounder.RoundInt64(long value) is not implemented in Uno.");
        }
#endif
#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
        [global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
        public ulong RoundUInt64(ulong value)
        {
            throw new global::System.NotImplementedException("The member ulong IncrementNumberRounder.RoundUInt64(ulong value) is not implemented in Uno.");
        }
#endif
#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
        [global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
        public float RoundSingle(float value)
        {
            throw new global::System.NotImplementedException("The member float IncrementNumberRounder.RoundSingle(float value) is not implemented in Uno.");
        }
#endif
        public double RoundDouble(double value)
        {
            var rounded = value / increment;
            rounded = Rounder.Round(rounded, 0, RoundingAlgorithm);
            rounded *= increment;

            return rounded;
        }
       
    }
}
