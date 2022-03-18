using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace TestStringFormat
{
    [TestClass]
    public class UnitTest1
    {
       
        [TestMethod]
        public void TestMethod1()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("hellosomespace");
            stringBuilder.Append("another text is comming");
            stringBuilder.Append("another text is comming");
            stringBuilder.Append("another text is comming");
            stringBuilder.Append("another text is comming");
            stringBuilder.Append("os k t a b");
            stringBuilder.Append("os k t a b");
            stringBuilder.Append("os k t a b");
            stringBuilder.Append("os k t a b");
            stringBuilder.Append("os k t a b");

            var stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < 100_000; i++)
            {
                stringBuilder.IndexOf(' ');
            }
            
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var str = "hellosomespaceanother text is comminganother text is comminganother text is comminganother text is commingos k t a bos k t a bos k t a bos k t a bos k t a b";

            var stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < 100_000; i++)
            {
                str.IndexOf(" ", StringComparison.Ordinal);
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
       
    }
}
