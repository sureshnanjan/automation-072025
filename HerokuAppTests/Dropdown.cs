using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

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
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }

        [TestMethod]
        public void Test_DropdownIsDisplayed()
        {
            // Arrange
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dropdown");

            // Act
            var dropdown = driver.FindElement(By.Id("dropdown"));

            // Assert
            Assert.IsTrue(dropdown.Displayed, "Dropdown is not displayed.");
            Assert.IsTrue(dropdown.Enabled, "Dropdown is not enabled.");
        }

        [TestMethod]
        public void Test_DefaultSelectedOption()
        {
            // Arrange
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dropdown");
            var dropdown = new SelectElement(driver.FindElement(By.Id("dropdown")));

            // Act
            var selectedOption = dropdown.SelectedOption;

            // Assert
            Assert.AreEqual("Please select an option", selectedOption.Text);
        }

        [TestMethod]
        public void Test_SelectOption1()
        {
            // Arrange
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dropdown");
            var dropdown = new SelectElement(driver.FindElement(By.Id("dropdown")));

            // Act
            dropdown.SelectByText("Option 1");

            // Assert
            Assert.AreEqual("Option 1", dropdown.SelectedOption.Text);
            Assert.AreEqual("1", dropdown.SelectedOption.GetAttribute("value"));
        }

        [TestMethod]
        public void Test_SelectOption2()
        {
            // Arrange
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dropdown");
            var dropdown = new SelectElement(driver.FindElement(By.Id("dropdown")));

            // Act
            dropdown.SelectByText("Option 2");

            // Assert
            Assert.AreEqual("Option 2", dropdown.SelectedOption.Text);
            Assert.AreEqual("2", dropdown.SelectedOption.GetAttribute("value"));
        }

        [TestMethod]
        public void Test_AllOptionsArePresent()
        {
            // Arrange
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dropdown");
            var dropdown = new SelectElement(driver.FindElement(By.Id("dropdown")));

            // Act
            var optionTexts = dropdown.Options.Select(o => o.Text).ToList();

            // Assert
            CollectionAssert.AreEqual(
                new List<string> { "Please select an option", "Option 1", "Option 2" },
                optionTexts,
                "Dropdown options do not match expected list."
            );
        }
    }
}
