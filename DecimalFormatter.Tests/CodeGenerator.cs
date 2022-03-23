using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.Globalization.NumberFormatting;

namespace DecimalFormatterTests.UWP
{
    [TestClass]
    public class CodeGenerator
    {
        [TestMethod]
        public void GenerateCurrencyDataClass()
        {
            var dir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var stringBuilder = new StringBuilder();
            var fieldStringBuilder = new StringBuilder();

            var type = typeof(Windows.Globalization.CurrencyIdentifiers);
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Static);

            foreach (var prop in props)
            {
                var value = prop.GetValue(null, null);
                var currencyCode = (string)value;

                try
                {
                    var formatter = new CurrencyFormatter(currencyCode);
                    var formatted = formatter.FormatDouble(1d);
                    var index = formatted.IndexOf('1');

                    var symbol = formatted.Remove(index, 1 + (formatter.FractionDigits > 0 ? formatter.FractionDigits + 1 : 0));

                    fieldStringBuilder.AppendLine($"private static readonly CurrencyData _{currencyCode.ToLowerInvariant()}CurrencyData = new CurrencyData {{ CurrencyCode = CurrencyIdentifiers.{currencyCode}CurrencyIdentifier, Symbol = \"{symbol}\", DefaultFractionDigits = {formatter.FractionDigits} }};");

                    stringBuilder.AppendLine($"case CurrencyIdentifiers.{currencyCode}CurrencyIdentifier:");
                    stringBuilder.AppendLine($"\t return _{currencyCode.ToLowerInvariant()}CurrencyData;");
                }
                catch (Exception)
                {
                }
            }

            var path = Path.Combine(dir, "generatedSwitchCases.cs");
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

        [TestMethod]
        public void GenerateCurrencyIndentifiers()
        {
            var type = typeof(Windows.Globalization.CurrencyIdentifiers);
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Static);

            var propBuilder = new StringBuilder();
            var constsBuilder = new StringBuilder();

            foreach (var prop in props)
            {
                var value = prop.GetValue(null, null);
                var currencyCode = (string)value;
                var propName = prop.Name;
                constsBuilder.AppendLine($"internal const string {propName}CurrencyIdentifier = \"{currencyCode}\";");
                propBuilder.AppendLine($"public static string {propName} => {propName}CurrencyIdentifier;");
            }

            constsBuilder.AppendLine();
            propBuilder.Insert(0, constsBuilder.ToString());

            var dir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var path = Path.Combine(dir, "generatedCurrencyIdentifiers.cs");
            File.WriteAllText(path, propBuilder.ToString());
        }
    }
}
