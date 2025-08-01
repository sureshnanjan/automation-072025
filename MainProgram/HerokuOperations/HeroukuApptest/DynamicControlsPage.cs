using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace HerokuOperations
{
    // Interface for dynamic controls
    public interface IDynamicControlsPage
    {
        // Checkbox section
        void ClickRemoveOrAddButton();
        bool IsCheckboxDisplayed();
        string GetCheckboxMessage();

        // Input field section
        void ClickEnableOrDisableButton();
        bool IsInputEnabled();
        void EnterText(string text);
        string GetInputMessage();
    }

    // Implementation of the interface using Selenium
    public class DynamicControlsPage : IDynamicControlsPage
    {
        private readonly IWebDriver _driver;

        public DynamicControlsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickRemoveOrAddButton()
        {
            _driver.FindElement(By.CssSelector("#checkbox-example button")).Click();
        }

        public bool IsCheckboxDisplayed()
        {
            try
            {
                return _driver.FindElement(By.Id("checkbox")).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public string GetCheckboxMessage()
        {
            return _driver.FindElement(By.Id("message")).Text;
        }

        public void ClickEnableOrDisableButton()
        {
            _driver.FindElement(By.CssSelector("#input-example button")).Click();
        }

        public bool IsInputEnabled()
        {
            return _driver.FindElement(By.CssSelector("#input-example input")).Enabled;
        }

        public string GetInputMessage()
        {
            return _driver.FindElement(By.Id("message")).Text;
        }

        public void EnterText(string text)
        {
            var inputField = _driver.FindElement(By.CssSelector("#input-example input"));
            inputField.Clear();
            inputField.SendKeys(text);
        }
    }

    // Test cases using MSTest
    [TestClass]
    public class DynamicControlsTests
    {
        private IWebDriver driver;
        private IDynamicControlsPage dynamicPage;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_controls");
            dynamicPage = new DynamicControlsPage(driver);
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();
        }

        [TestMethod]
        public void Test_PageTitle()
        {
            Assert.AreEqual("The Internet", driver.Title);
        }

        [TestMethod]
        public void Test_RemoveCheckbox()
        {
            dynamicPage.ClickRemoveOrAddButton();
            Thread.Sleep(2000);
            Assert.IsFalse(dynamicPage.IsCheckboxDisplayed());
            Assert.AreEqual("It's gone!", dynamicPage.GetCheckboxMessage());
        }

        [TestMethod]
        public void Test_AddCheckboxBack()
        {
            dynamicPage.ClickRemoveOrAddButton(); // Remove first
            Thread.Sleep(2000);
            dynamicPage.ClickRemoveOrAddButton(); // Add back
            Thread.Sleep(2000);
            Assert.IsTrue(dynamicPage.IsCheckboxDisplayed());
            Assert.AreEqual("It's back!", dynamicPage.GetCheckboxMessage());
        }

        [TestMethod]
        public void Test_EnableInput()
        {
            dynamicPage.ClickEnableOrDisableButton();
            Thread.Sleep(2000);
            Assert.IsTrue(dynamicPage.IsInputEnabled());
            Assert.AreEqual("It's enabled!", dynamicPage.GetInputMessage());
        }

        [TestMethod]
        public void Test_DisableInput()
        {
            dynamicPage.ClickEnableOrDisableButton(); // Enable first
            Thread.Sleep(2000);
            dynamicPage.ClickEnableOrDisableButton(); // Then disable
            Thread.Sleep(2000);
            Assert.IsFalse(dynamicPage.IsInputEnabled());
            Assert.AreEqual("It's disabled!", dynamicPage.GetInputMessage());
        }

        [TestMethod]
        public void Test_EnterText()
        {
            dynamicPage.ClickEnableOrDisableButton();
            Thread.Sleep(2000);
            if (dynamicPage.IsInputEnabled())
            {
                dynamicPage.EnterText("Hello Selenium");
                Assert.IsTrue(true); // Passed if no exception
            }
            else
            {
                Assert.Fail("Input field was not enabled.");
            }
        }
    }
}
