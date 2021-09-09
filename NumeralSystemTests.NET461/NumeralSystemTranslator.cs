using System;
using System.Collections.Generic;
using System.Linq;

namespace Windows.Globalization.NumberFormatting
{
    public partial class NumeralSystemTranslator
    {
        public string NumeralSystem { get; set; }
        public IReadOnlyList<string> Languages { get; }
        public string ResolvedLanguage { get; }

        public NumeralSystemTranslator(IEnumerable<string> languages)
        {
            Languages = languages.ToList();
        }
        public NumeralSystemTranslator()
        {
            Languages = new string[] { "en-US" };
            NumeralSystem = "Latin";
            ResolvedLanguage = "en-US";
        }
       
        public string TranslateNumerals(string value)
        {
            if (NumeralSystem == "Arab")
            {
                return Translate(value, TranslateToArab);
            }
            else if (NumeralSystem == "ArabExt")
            {
                return Translate(value, TranslateToArabExt);
            }

            return value;
        }

        private static string Translate(string value, Func<char, char> translateFunc)
        {
            var chars = value.ToCharArray();
            
            for (int i = 0; i < chars.Length; i++)
            {
                var c = chars[i];
                chars[i] = translateFunc(c);
            }

            return new string(chars);
        }

        private static char TranslateToArab(char latin)
        {
            switch (latin)
            {
                case '0': return '\u0660';
                case '1': return '\u0661';
                case '2': return '\u0662';
                case '3': return '\u0663';
                case '4': return '\u0664';
                case '5': return '\u0665';
                case '6': return '\u0666';
                case '7': return '\u0667';
                case '8': return '\u0668';
                case '9': return '\u0669';
                case ',': return '\u066c';
                case '%': return '\u066a';
                case '\u2030': return '\u0609'; //Per Mille Symbol
                default: return latin;
            }
        }

        private static char TranslateToArabExt(char latin)
        {
            switch (latin)
            {
                case '0': return '\u06F0';
                case '1': return '\u06F1';
                case '2': return '\u06F2';
                case '3': return '\u06F3';
                case '4': return '\u06F4';
                case '5': return '\u06F5';
                case '6': return '\u06F6';
                case '7': return '\u06F7';
                case '8': return '\u06F8';
                case '9': return '\u06F9';
                case ',': return '\u066c';
                case '%': return '\u066a';
                case '\u2030': return '\u0609'; //Per Mille Symbol
                default: return latin;
            }
        }
    }
}
