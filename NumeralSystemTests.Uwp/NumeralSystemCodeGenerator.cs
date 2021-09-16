using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Globalization.NumberFormatting;
using Windows.Storage;

namespace NumeralSystemTests.Uwp
{
    [TestClass]
    public class NumeralSystemCodeGenerator
    {
        [TestMethod]
        public void GenerateNumeralSystem()
        {
            var exportAddress = Path.Combine(ApplicationData.Current.LocalFolder.Path, "numeralSystems.cs");
            var address = Path.Combine(ApplicationData.Current.LocalFolder.Path, "language-tags.csv");
            var languageTags = File.ReadAllLines(address);

            var stringBuilder = new StringBuilder();
            int count = 0;

            foreach (var languageTag in languageTags)
            {
                try
                {
                    var translator = new NumeralSystemTranslator(new string[] { languageTag });
                    var numeralSystem = translator.NumeralSystem;
                    stringBuilder.AppendLine($"{{ \"{languageTag}\", \"{numeralSystem}\" }},");
                    count++;
                }
                catch (ArgumentException)
                {
                    stringBuilder.AppendLine($"// {{ \"{languageTag}\", \"\" }}, throws exception");
                }
            }

            stringBuilder.AppendLine(count.ToString());
            File.WriteAllText(exportAddress, stringBuilder.ToString());
        }

        [TestMethod]
        public void GenerateResolvedLanguage()
        {
            var exportAddress = Path.Combine(ApplicationData.Current.LocalFolder.Path, "resolvedLanguage.cs");
            var address = Path.Combine(ApplicationData.Current.LocalFolder.Path, "language-tags.csv");
            var languageTags = File.ReadAllLines(address);

            var stringBuilder = new StringBuilder();
            int count = 0;

            foreach (var languageTag in languageTags)
            {
                try
                {
                    var translator = new NumeralSystemTranslator(new string[] { languageTag });
                    var resolvedLanguage = translator.ResolvedLanguage;
                    stringBuilder.AppendLine($"{{ \"{languageTag}\", \"{resolvedLanguage}\" }},");
                    count++;
                }
                catch (ArgumentException)
                {
                    stringBuilder.AppendLine($"// {{ \"{languageTag}\", \"\" }}, throws exception");
                }
            }

            stringBuilder.AppendLine(count.ToString());
            File.WriteAllText(exportAddress, stringBuilder.ToString());
        }


        [TestMethod]
        public void GenerateDigitsArray()
        {
            var exportAddress = Path.Combine(ApplicationData.Current.LocalFolder.Path, "digits.cs");
            var address = Path.Combine(ApplicationData.Current.LocalFolder.Path, "numeralSystemCharacters.csv");
            var lines = File.ReadAllLines(address);

            var stringBuilder = new StringBuilder();

            foreach (var line in lines)
            {
                var fields = line.Split(',');
                var numeralSystem = fields[0];
                stringBuilder.Append($"{{ \"{numeralSystem}\", new char[] {{ ");
                for (int i = 2; i < 11; i++)
                {
                    stringBuilder.Append($"'{GetUnicodeChar(fields[i])}', ");
                }
                stringBuilder.Append($"'{GetUnicodeChar(fields[11])}'");
                stringBuilder.AppendLine(" } },");
            }

            File.WriteAllText(exportAddress, stringBuilder.ToString());
        }

        private string GetUnicodeChar(string input)
        {
            var r = input.Trim().Substring(2);
            return "\\u" + r;
        }

    }
}
