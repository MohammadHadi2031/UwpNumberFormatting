
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Windows.Globalization.NumberFormatting
{
    [TestClass]
    public class Given_NumeralSystemTranslator
    {
        [DataTestMethod]
        [DataRow("1,234,567,890.12 % ‰", "Arab", "١٬٢٣٤٬٥٦٧٬٨٩٠٫١٢ % ‰")]
        [DataRow("1,234,567,890.12%", "Arab", "١٬٢٣٤٬٥٦٧٬٨٩٠٫١٢%")]
        [DataRow("1,234,567,890.12 % ‰", "ArabExt", "۱٬۲۳۴٬۵۶۷٬۸۹۰٫۱۲ % ‰")]
        public void When_NumeralSystemIsArab(string value, string numeralSystem, string expected)
        {
            NumeralSystemTranslator numeralSystemTranslator = new NumeralSystemTranslator();
            numeralSystemTranslator.NumeralSystem = numeralSystem;
            var translated = numeralSystemTranslator.TranslateNumerals(value);
            Assert.AreEqual(expected, translated);
        }
    }
}
