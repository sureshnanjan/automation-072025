// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomePageTests.cs" company="AscendionQA">
//   Copyright (c) 2025 AscendionQA. All rights reserved.
//   Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
// HEROKUAPP HOMEPAGE TESTCASES
using OpenQA.Selenium.Chrome;             // Import Selenium Chrome WebDriver
using OpenQA.Selenium;                    // Import Selenium WebDriver interface
using Microsoft.VisualStudio.TestTools.UnitTesting; // Import MSTest framework for writing test cases

namespace HerokuAppTests
{
    /// <summary>
    /// This test class contains automated UI tests for the "https://the-internet.herokuapp.com/" home page.
    /// It verifies page title, subtitle, example count, and checks the 10th item in the list.
    /// </summary>
    [TestClass] // Marks this class as containing test methods for MSTest
    public sealed class HomePageTests
    {
        /// <summary>
        /// Verifies that the page's main heading (H1 tag) is "Welcome to the-internet".
        /// </summary>
        [TestMethod]
        public void TitleisOK()
        {
            // Arrange
            var expectedTitle = "Welcome to the-internet"; // Expected text in the main heading
            ChromeDriver driver = new ChromeDriver();       // Launch a new Chrome browser instance
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/"); // Open the target URL
            IWebElement pageheading = driver.FindElement(By.TagName("h1"));   // Locate the <h1> element on the page

            // Act
            var actualTitle = pageheading.Text; // Extract the text from the located <h1> element

            // Assert
            Assert.AreEqual(expectedTitle, actualTitle); // Verify that the actual text matches the expected text

            driver.Quit(); // Close the browser
        }

        /// <summary>
        /// Verifies that the page's sub-heading (H2 tag) is "Available Examples".
        /// </summary>
        [TestMethod]
        public void SubTitleisOK()
        {
            // Arrange
            var expectedSubTitle = "Available Examples";   // Expected text in the subheading
            ChromeDriver driver = new ChromeDriver();       // Launch a new Chrome browser instance
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/"); // Open the target URL
            IWebElement subtitleElement = driver.FindElement(By.TagName("h2")); // Locate the <h2> element

            // Act
            var actualSubTitle = subtitleElement.Text; // Extract the text from the <h2> element

            // Assert
            Assert.AreEqual(expectedSubTitle, actualSubTitle); // Verify the text matches the expectation

            driver.Quit(); // Close the browser
        }

        /// <summary>
        /// Verifies that the number of example links in the list is 44.
        /// </summary>
        [TestMethod]
        public void ExamplesCountis44()
        {
            // Arrange
            var expectedCount = 44; // Expected number of list items
            ChromeDriver driver = new ChromeDriver();       // Launch Chrome browser
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/"); // Open the target URL

            // Act
            var exampleItems = driver.FindElements(By.CssSelector("ul li")); // Locate all <li> elements inside <ul>
            var actualCount = exampleItems.Count; // Count how many items are present

            // Assert
            Assert.AreEqual(expectedCount, actualCount); // Verify the count matches the expected value

            driver.Quit(); // Close the browser
        }

        /// <summary>
        /// Verifies that the 10th element in the examples list is "Drag and Drop".
        /// </summary>
        [TestMethod]
        public void TenthElementIsDragAndDrop()
        {
            // Arrange
            var expectedText = "Drag and Drop"; // Expected text for the 10th list item
            ChromeDriver driver = new ChromeDriver();        // Launch a new Chrome browser instance
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/"); // Navigate to the page

            // Act
            IWebElement tenthElement = driver.FindElement(By.XPath("/html/body/div[2]/div/ul/li[10]/a"));
            // Locate the 10th <li> element (absolute XPath)

            var actualText = tenthElement.Text; // Get the text content of the 10th element

            // Assert
            Assert.AreEqual(expectedText, actualText,
                $"The 10th element text was '{actualText}', expected '{expectedText}'.");
            // Verify the 10th element's text matches the expected value

            driver.Quit(); // Close the browser
        }
    }
}
