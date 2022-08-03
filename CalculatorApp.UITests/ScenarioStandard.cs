using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;


namespace CalculatorApp.UITests
{
    [TestClass]
    public class ScenarioStandard : CalculatorSession
    {
        private static WindowsElement calculatorResult;
        private static WindowsElement clearButton;

        [TestMethod]
        public void Buttons()
        {
            Assert.IsFalse(session.FindElementByAccessibilityId("Add").Enabled);
            Assert.IsFalse(session.FindElementByAccessibilityId("Substract").Enabled);
            Assert.IsFalse(session.FindElementByAccessibilityId("Multiply").Enabled);
            Assert.IsFalse(session.FindElementByAccessibilityId("Divide").Enabled);
            Assert.IsFalse(session.FindElementByAccessibilityId("Equals").Enabled);
            session.FindElementByAccessibilityId("One").Click();
            session.FindElementByAccessibilityId("Two").Click();
            session.FindElementByAccessibilityId("Three").Click();
            session.FindElementByAccessibilityId("Four").Click();
            session.FindElementByAccessibilityId("Five").Click();
            session.FindElementByAccessibilityId("Six").Click();
            session.FindElementByAccessibilityId("Seven").Click();
            session.FindElementByAccessibilityId("Eight").Click();
            session.FindElementByAccessibilityId("Nine").Click();
            session.FindElementByAccessibilityId("Zero").Click();
            Assert.AreEqual("1234567890", calculatorResult.Text);
        }

        [TestMethod]
        public void Addition()
        {
            session.FindElementByAccessibilityId("Three").Click();
            session.FindElementByAccessibilityId("Add").Click();
            session.FindElementByAccessibilityId("Five").Click();
            session.FindElementByAccessibilityId("Equals").Click();
            Assert.AreEqual("8", calculatorResult.Text);
        }

        [TestMethod]
        public void Substraction()
        {
            session.FindElementByAccessibilityId("One").Click();
            session.FindElementByAccessibilityId("Two").Click();
            session.FindElementByAccessibilityId("Substract").Click();
            session.FindElementByAccessibilityId("Four").Click();
            session.FindElementByAccessibilityId("Equals").Click();
            Assert.AreEqual("8", calculatorResult.Text);
        }

        [TestMethod]
        public void Multiplication()
        {
            session.FindElementByAccessibilityId("Two").Click();
            session.FindElementByAccessibilityId("Multiply").Click();
            session.FindElementByAccessibilityId("Four").Click();
            session.FindElementByAccessibilityId("Equals").Click();
            Assert.AreEqual("8", calculatorResult.Text);
        }

        [TestMethod]
        public void Division()
        {
            session.FindElementByAccessibilityId("Two").Click();
            session.FindElementByAccessibilityId("Four").Click();
            session.FindElementByAccessibilityId("Divide").Click();
            session.FindElementByAccessibilityId("Three").Click();
            session.FindElementByAccessibilityId("Equals").Click();
            Assert.AreEqual("8", calculatorResult.Text);
        }

        [TestMethod]
        public void Deicmals()
        {
            session.FindElementByAccessibilityId("Decimal").Click();
            Assert.IsFalse(session.FindElementByAccessibilityId("Decimal").Enabled);
            session.FindElementByAccessibilityId("Five").Click();
            Assert.AreEqual(".5", calculatorResult.Text);
        }

        [TestMethod]
        public void ReverseSign()
        {
            session.FindElementByAccessibilityId("Five").Click();
            session.FindElementByAccessibilityId("ReverseSign").Click();
            Assert.AreEqual("-5", calculatorResult.Text);
            session.FindElementByAccessibilityId("ReverseSign").Click();
            Assert.AreEqual("5", calculatorResult.Text);
        }

        [TestMethod]
        public void MultipleOperations()
        {
            session.FindElementByAccessibilityId("Two").Click();
            session.FindElementByAccessibilityId("Add").Click();
            session.FindElementByAccessibilityId("Two").Click();
            session.FindElementByAccessibilityId("Multiply").Click();
            session.FindElementByAccessibilityId("Two").Click();
            session.FindElementByAccessibilityId("Substract").Click();
            Assert.AreEqual("8", calculatorResult.Text);
        }
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Setup(context);
            calculatorResult = session.FindElementByAccessibilityId("Output");

        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TearDown();
        }

        [TestInitialize]
        public void SetupTest()
        {
            clearButton = session.FindElementByAccessibilityId("Clear");
            clearButton.Click();
            Assert.AreEqual("", calculatorResult.Text);
        }

    }
}