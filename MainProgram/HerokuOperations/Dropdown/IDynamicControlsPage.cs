using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace HerokuTests
{
    [TestClass]
    public class DynamicControlsTests
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_controls");
        }

        [TestMethod]
        public void Test_RemoveAndAddCheckbox()
        {
            var removeButton = driver.FindElement(By.XPath("//form[@id='checkbox-example']//button"));
            removeButton.Click();

            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => !IsElementPresent(By.Id("checkbox")));

            Assert.IsFalse(IsElementPresent(By.Id("checkbox")), "Checkbox should be removed.");

            var addButton = driver.FindElement(By.XPath("//form[@id='checkbox-example']//button"));
            addButton.Click();

            wait.Until(d => IsElementPresent(By.Id("checkbox")));
            Assert.IsTrue(IsElementPresent(By.Id("checkbox")), "Checkbox should be added back.");
        }

        [TestMethod]
        public void Test_EnableAndDisableTextbox()
        {
            var enableButton = driver.FindElement(By.XPath("//form[@id='input-example']//button"));
            enableButton.Click();

            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.XPath("//form[@id='input-example']/input")).Enabled);

            Assert.IsTrue(driver.FindElement(By.XPath("//form[@id='input-example']/input")).Enabled, "Textbox should be enabled.");

            enableButton = driver.FindElement(By.XPath("//form[@id='input-example']//button"));
            enableButton.Click();

            wait.Until(d => !d.FindElement(By.XPath("//form[@id='input-example']/input")).Enabled);
            Assert.IsFalse(driver.FindElement(By.XPath("//form[@id='input-example']/input")).Enabled, "Textbox should be disabled.");
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}
