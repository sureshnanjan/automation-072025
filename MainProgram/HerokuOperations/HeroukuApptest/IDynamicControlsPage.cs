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
        private IDynamicControlsPage page;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_controls");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            page = new HerokuOperations.DynamicControlsPage(driver); // Use the concrete implementation
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();
        }

        [TestMethod]
        public void Checkbox_Remove_Then_Add()
        {
            // Remove
            page.ClickRemoveOrAddButton();
            Assert.IsFalse(page.IsCheckboxDisplayed(), "Checkbox should be removed.");
            Assert.AreEqual("It's gone!", page.GetCheckboxMessage());

            // Add
            page.ClickRemoveOrAddButton();
            Assert.IsTrue(page.IsCheckboxDisplayed(), "Checkbox should be added back.");
            Assert.AreEqual("It's back!", page.GetCheckboxMessage());
        }

        [TestMethod]
        public void Input_Enable_Then_Disable()
        {
            // Enable
            page.ClickEnableOrDisableButton();
            Assert.IsTrue(page.IsInputEnabled(), "Input field should be enabled.");
            Assert.AreEqual("It's enabled!", page.GetInputMessage());

            // Type text
            page.EnterText("Selenium Test");

            // Disable
            page.ClickEnableOrDisableButton();
            Assert.IsFalse(page.IsInputEnabled(), "Input field should be disabled.");
            Assert.AreEqual("It's disabled!", page.GetInputMessage());
        }
    }
    public interface IDynamicControlsPage
    {
        void ClickRemoveOrAddButton();
        bool IsCheckboxDisplayed();
        string GetCheckboxMessage();
        void ClickEnableOrDisableButton();
        bool IsInputEnabled();
        string GetInputMessage();
        void EnterText(string text);
    }
}
