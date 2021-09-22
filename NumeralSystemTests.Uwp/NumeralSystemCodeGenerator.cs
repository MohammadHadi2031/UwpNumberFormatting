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

            foreach (var languageTag in languageTags)
            {
                try
                {
                    var translator = new NumeralSystemTranslator(new string[] { languageTag });
                    var numeralSystem = translator.NumeralSystem;

                    stringBuilder.AppendLine($"case \"{languageTag.ToLowerInvariant()}\":");
                    stringBuilder.AppendLine($"\treturn \"{numeralSystem}\";");

                }
                catch (ArgumentException)
                {
                }
            }

            File.WriteAllText(exportAddress, stringBuilder.ToString());
        }

        [TestMethod]
        public void GenerateResolvedLanguage()
        {
            var exportAddress = Path.Combine(ApplicationData.Current.LocalFolder.Path, "resolvedLanguage.cs");
            var address = Path.Combine(ApplicationData.Current.LocalFolder.Path, "language-tags.csv");
            var languageTags = File.ReadAllLines(address);

            var stringBuilder = new StringBuilder();

            foreach (var languageTag in languageTags)
            {
                try
                {
                    var translator = new NumeralSystemTranslator(new string[] { languageTag });
                    var resolvedLanguage = translator.ResolvedLanguage;

                    stringBuilder.AppendLine($"case \"{languageTag.ToLowerInvariant()}\":");
                    stringBuilder.AppendLine($"\treturn \"{resolvedLanguage}\";");
                }
                catch (ArgumentException)
                {
                }
            }

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

        [TestMethod]
        public void GenerateInitializeTestData()
        {
            var exportAddress = Path.Combine(ApplicationData.Current.LocalFolder.Path, "numeralSystemsTests.cs");
            var address = Path.Combine(ApplicationData.Current.LocalFolder.Path, "language-tags.csv");
            var languageTags = File.ReadAllLines(address);

            var stringBuilder = new StringBuilder();

            foreach (var languageTag in languageTags)
            {
                try
                {
                    var translator = new NumeralSystemTranslator(new string[] { languageTag });
                    var numeralSystem = translator.NumeralSystem;
                    var reslovedLanguage = translator.ResolvedLanguage;
                    stringBuilder.AppendLine($"yield return new object[] {{ \"{languageTag}\", \"{numeralSystem}\", \"{reslovedLanguage}\" }};");
                }
                catch (ArgumentException)
                {
                }
            }

            File.WriteAllText(exportAddress, stringBuilder.ToString());
        }

        [TestMethod]
        public void GenerateTranslateTestData()
        {
            var exportAddress = Path.Combine(ApplicationData.Current.LocalFolder.Path, "translateTestData.cs");
            var address = Path.Combine(ApplicationData.Current.LocalFolder.Path, "numeralSystemCharacters.csv");
            var lines = File.ReadAllLines(address);

            var stringBuilder = new StringBuilder();

            foreach (var line in lines)
            {
                var fields = line.Split(',');
                var numeralSystem = fields[0];
                var translator = new NumeralSystemTranslator { NumeralSystem = numeralSystem };

                stringBuilder.AppendLine("[DataTestMethod]");
                stringBuilder.AppendLine($"[DataRow(\"0\", \"{translator.TranslateNumerals("0")}\")]");
                stringBuilder.AppendLine($"[DataRow(\"1\", \"{translator.TranslateNumerals("1")}\")]");
                stringBuilder.AppendLine($"[DataRow(\"2\", \"{translator.TranslateNumerals("2")}\")]");
                stringBuilder.AppendLine($"[DataRow(\"3\", \"{translator.TranslateNumerals("3")}\")]");
                stringBuilder.AppendLine($"[DataRow(\"4\", \"{translator.TranslateNumerals("4")}\")]");
                stringBuilder.AppendLine($"[DataRow(\"5\", \"{translator.TranslateNumerals("5")}\")]");
                stringBuilder.AppendLine($"[DataRow(\"6\", \"{translator.TranslateNumerals("6")}\")]");
                stringBuilder.AppendLine($"[DataRow(\"7\", \"{translator.TranslateNumerals("7")}\")]");
                stringBuilder.AppendLine($"[DataRow(\"8\", \"{translator.TranslateNumerals("8")}\")]");
                stringBuilder.AppendLine($"[DataRow(\"9\", \"{translator.TranslateNumerals("9")}\")]");
                stringBuilder.AppendLine($"[DataRow(\"0%\", \"{translator.TranslateNumerals("0%")}\")]");
                stringBuilder.AppendLine($"[DataRow(\"123,4\", \"{translator.TranslateNumerals("123,4")}\")]");
                stringBuilder.AppendLine($"[DataRow(\"123.4\", \"{translator.TranslateNumerals("123.4")}\")]");

                stringBuilder.AppendLine($"public void When_NumeralSystemIs{numeralSystem}(string value, string expected)");
                stringBuilder.AppendLine("{");
                stringBuilder.AppendLine($"When_NumeralSystemIsSpecific(value, expected, \"{numeralSystem}\");");
                stringBuilder.AppendLine("}");
                stringBuilder.AppendLine();
            }

            File.WriteAllText(exportAddress, stringBuilder.ToString());
        }
    }
}
