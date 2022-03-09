using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;

namespace NumberBoxApp.UITests
{
    [TestClass]
    public class UnitTest1 : Session
    {
        private static WindowsElement numberBox;
        private static WindowsElement newValueTextBox;

        [TestMethod]
        public void TestMethod1()
        {
            numberBox.Clear();
            numberBox.SendKeys("1.7"); //۱٫۷
            numberBox.SendKeys(Keys.Enter);

            var text = numberBox.Text;
            var value = newValueTextBox.Text;

            Assert.AreEqual(expected: "1.7", actual: text); 
            Assert.AreEqual(expected: "1.7", actual: value);

            numberBox.SendKeys(Keys.Enter);

             text = numberBox.Text;
             value = newValueTextBox.Text;

            Assert.AreEqual(expected: "1.75", actual: text); //"۱٫۷۵"
            Assert.AreEqual(expected: "1.75", actual: value);
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Setup(context);
            numberBox = session.FindElementByName("TestNumberBox");
            newValueTextBox = session.FindElementByName("NewValueTextBox");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TearDown();
        }
    }
}
