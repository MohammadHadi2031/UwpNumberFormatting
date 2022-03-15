﻿using System;

namespace Windows.Globalization.NumberFormatting
{
    internal static class Extensions
    {
        public static bool IsNegative(this double value) => BitConverter.DoubleToInt64Bits(value) < 0;
    }
}
