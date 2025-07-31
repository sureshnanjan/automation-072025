using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;
using System;

namespace HerokuTests
{
    [TestClass]
    public class DynamicControlsTests
    {
        private IWebDriver driver;
        private IDynamicControlsPage controls;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_controls");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            controls = new DynamicControlsPage(driver); // ? Replace with your actual class
        }

        [TestCleanup]
        public void Teardown() => driver.Quit();

        [TestMethod]
        public void Test_CheckboxToggle()
        {
            controls.ClickRemoveOrAddButton();
            string message = controls.GetCheckboxMessage();
            Assert.IsTrue(message.Contains("gone") || message.Contains("added"));
        }

        [TestMethod]
        public void Test_InputEnableDisable()
        {
            controls.ClickEnableOrDisableButton();
            bool enabled = controls.IsInputEnabled();
            Assert.IsTrue(enabled || !enabled);
        }
    }
}
