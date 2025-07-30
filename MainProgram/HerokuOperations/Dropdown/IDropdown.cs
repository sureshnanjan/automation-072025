using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace DropdownTests
{
    [TestClass]
    public class DropdownTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [TestInitialize]
        public void Setup()
        {
            // Arrange: Setup browser
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dropdown");
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [TestMethod]
        public void SelectDropdownOption1()
        {  }

        [TestMethod]
        public void SelectDropdownOption2()
        { }

        [TestCleanup]
        public void TearDown()
        {}
    }
}
