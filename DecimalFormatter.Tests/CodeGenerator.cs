using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Globalization.NumberFormatting;

namespace DecimalFormatterTests.UWP
{
    [TestClass]
    public class CodeGenerator
    {
        [TestMethod]
        public void GenerateSymbolSwitchCases()
        {
            var dir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var path = Path.Combine(dir, "currency.csv");
            var lines = File.ReadAllLines(path);
            var stringBuilder = new StringBuilder();
            var fieldStringBuilder = new StringBuilder();

            foreach (var line in lines)
            {
                var parameters = line.Split(',');
                var currencyCode = parameters[1];
                //var symbol = parameters[2];

                try
                {
                    var formatter = new CurrencyFormatter(currencyCode);
                    var formatted = formatter.FormatDouble(1d);
                    var index = formatted.IndexOf('1');

                    var symbol = formatted.Remove(index, 1 + (formatter.FractionDigits > 0 ? formatter.FractionDigits + 1 : 0));

                    fieldStringBuilder.AppendLine($"private static readonly CurrencyData _{currencyCode.ToLowerInvariant()}CurrencyData = new CurrencyData {{ CurrencyCode = \"{currencyCode}\", Symbol = \"{symbol}\", DefaultFractionDigits = {formatter.FractionDigits} }};");

                    stringBuilder.AppendLine($"case \"{currencyCode}\":");
                    stringBuilder.AppendLine($"\t return _{currencyCode.ToLowerInvariant()}CurrencyData;");
                }
                catch (Exception)
                {
                }
            }

            path = Path.Combine(dir, "generatedSwitchCases.cs");
            File.WriteAllText(path, stringBuilder.ToString());

            path = Path.Combine(dir, "generatedfield.cs");
            File.WriteAllText(path, fieldStringBuilder.ToString());
        }

        [TestMethod]
        public void GenerateFormatDoubleWithSpecialCurrencyCodeTestData()
        {
            var dir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var path = Path.Combine(dir, "currency.csv");
            var lines = File.ReadAllLines(path);
            var stringBuilder = new StringBuilder();

            foreach (var line in lines)
            {
                var parameters = line.Split(',');
                var currencyCode = parameters[1];

                try
                {
                    var formatter = new CurrencyFormatter(currencyCode);
                    var formatted = formatter.FormatDouble(1d);

                    stringBuilder.AppendLine($"[DataRow(\"{currencyCode}\", \"{formatted}\")]");
                }
                catch (Exception)
                {
                }
            }

            path = Path.Combine(dir, "generatedFormatDoubleWithSpecialCurrencyCodeTestData.cs");
            File.WriteAllText(path, stringBuilder.ToString());
        }

        [TestMethod]
        public void GenerateFormatDoubleWithSpecialCurrencyCodeAndCurrencyCodeModeTestData()
        {
            var dir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var path = Path.Combine(dir, "currency.csv");
            var lines = File.ReadAllLines(path);
            var stringBuilder = new StringBuilder();

            foreach (var line in lines)
            {
                var parameters = line.Split(',');
                var currencyCode = parameters[1];

                try
                {
                    var formatter = new CurrencyFormatter(currencyCode);
                    formatter.Mode = CurrencyFormatterMode.UseCurrencyCode;
                    var formatted = formatter.FormatDouble(1d);

                    stringBuilder.AppendLine($"[DataRow(\"{currencyCode}\", \"{formatted}\")]");
                }
                catch (Exception)
                {
                }
            }

            path = Path.Combine(dir, "generatedFormatDoubleWithSpecialCurrencyCodeAndCurrencyCodeModeTestData.cs");
            File.WriteAllText(path, stringBuilder.ToString());
        }
    }
}
