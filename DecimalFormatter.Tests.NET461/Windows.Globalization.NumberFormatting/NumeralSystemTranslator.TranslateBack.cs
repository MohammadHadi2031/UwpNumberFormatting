using System;
using Uno.Globalization.NumberFormatting;

namespace Windows.Globalization.NumberFormatting
{
    partial class NumeralSystemTranslator
	{
		public string TranslateBackNumerals(string value)
		{
			if (NumeralSystem.Equals("Arab", StringComparison.Ordinal) ||
				NumeralSystem.Equals("ArabExt", StringComparison.Ordinal))
			{
				return TranslateBackArab(value, NumeralSystemTranslatorHelper.GetDigitsSource(NumeralSystem));
			}

			return TranslateBack(value, NumeralSystemTranslatorHelper.GetDigitsSource(NumeralSystem));
		}

		private static string TranslateBackArab(string value, char[] digitsSource)
		{
			var chars = value.ToCharArray();

			for (int i = 0; i < chars.Length; i++)
			{
				var c = chars[i];

				switch (c)
				{
					case '\u066b':
						chars[i] = '.';
						break;
					case '\u066c':
						chars[i] = ',';
						break;
					case '\u066a':
						chars[i] = '%';
						break;
					case '\u0609': //Per Mille Symbol
						chars[i] = '\u2030';
						break;
					default:
						chars[i] = TranslateBack(c, digitsSource);
						break;
				}
			}

			return new string(chars);
		}

		private static string TranslateBack(string value, char[] digitsSource)
		{
			var chars = value.ToCharArray();

			for (int i = 0; i < chars.Length; i++)
			{
				chars[i] = TranslateBack(chars[i], digitsSource);
			}

			return new string(chars);
		}

		private static char TranslateBack(char c, char[] digitsSource)
		{
			var d = c - digitsSource[0];
			var t = c;

			if (d >= 0 && d <= 9)
			{
				t = (char)(d + '0');
			}

			return t;
		}
	}
}
