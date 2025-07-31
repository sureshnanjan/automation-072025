using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using HerokuOperations;

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

            page = new DynamicControlsPage(driver); // <-- Replace with your concrete implementation
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();
        }

        // --- Checkbox Section Tests ---

        [TestMethod]
        public void TestCheckboxRemoveAndAdd()
        {
            if (page.IsCheckboxDisplayed())
            {
                page.ClickRemoveOrAddButton();
                Thread.Sleep(3000); // Wait for AJAX animation
                Assert.IsFalse(page.IsCheckboxDisplayed(), "Checkbox should be removed.");
                Assert.AreEqual("It's gone!", page.GetCheckboxMessage());
            }

            page.ClickRemoveOrAddButton();
            Thread.Sleep(3000); // Wait for checkbox to reappear
            Assert.IsTrue(page.IsCheckboxDisplayed(), "Checkbox should be added back.");
            Assert.AreEqual("It's back!", page.GetCheckboxMessage());
        }

        // --- Input Field Section Tests ---

        [TestMethod]
        public void Test_Input_Enable_And_Disable()
        {
            if (!page.IsInputEnabled())
            {
                page.ClickEnableOrDisableButton();
                Thread.Sleep(3000); // Wait for enable
                Assert.IsTrue(page.IsInputEnabled(), "Input should be enabled.");
                Assert.AreEqual("It's enabled!", page.GetInputMessage());
            }

            page.EnterText("Test input");
            page.ClickEnableOrDisableButton();
            Thread.Sleep(3000); // Wait for disable
            Assert.IsFalse(page.IsInputEnabled(), "Input should be disabled.");
            Assert.AreEqual("It's disabled!", page.GetInputMessage());
        }
    }
}
