using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Globalization.NumberFormatting;

namespace Tests.NetCore
{
    [TestClass]
    public class CodeGenerator
    {
        [TestMethod]
        public void GenerateSwitchCases()
        {
            var path = @"D:\Desktop\currency.csv";
            var lines = File.ReadAllLines(path);

            var stringBuilder = new StringBuilder();

            foreach (var line in lines)
            {
                var parameters = line.Split(',');
                var currencyCode = parameters[1];
                var symbol = parameters[2];

                stringBuilder.AppendLine($"case \"{currencyCode}\":");
                stringBuilder.AppendLine($"\t return \"{symbol}\";");
            }

            File.WriteAllText("generatedSwitchCases.cs", stringBuilder.ToString());
        }

        public static string GetSymbol(string currencyCode)
        {
            switch (currencyCode)
            {
                case "USD":
                    return "$";
                default:
                    return "";
            }
        }

        [TestMethod]
        public void GenerateDataRow()
        {
            var path = @"D:\Desktop\currency.csv";
            var lines = File.ReadAllLines(path);

            var stringBuilder = new StringBuilder();

            foreach (var line in lines)
            {
                var parameters = line.Split(',');
                var currencyCode = parameters[1];
                var symbol = parameters[2];

                stringBuilder.AppendLine($"[DataRow(\"{currencyCode}\", \"{symbol}\")]");
            }

            File.WriteAllText("generatedDataRows.cs", stringBuilder.ToString());
        }

       

    }
}
