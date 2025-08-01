
﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HerokuAppTests
{
    /// <summary>
    /// Contains automated UI tests for validating key elements on the HerokuApp homepage.
    /// Each test follows the Arrange-Act-Assert pattern.
    /// </summary>
    [TestClass]
    public sealed class HomePageTests
    {
        /// <summary>
        /// Verifies that the main title (h1) of the HerokuApp homepage matches the expected text.
        /// 
        /// Arrange: Define the expected title and navigate to the homepage.
        /// Act: Locate the main heading element and extract its text.
        /// Assert: Check if the actual text equals the expected title.
        /// </summary>
        [TestMethod]
        public void TitleisOK()
        {
            var expectedTitle = "Welcome to the-internet";

            using (ChromeDriver driver = new ChromeDriver())
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
                IWebElement pageheading = driver.FindElement(By.TagName("h1"));
                var actualTitle = pageheading.Text;

                Assert.AreEqual(expectedTitle, actualTitle);
            }
        }

        /// <summary>
        /// Verifies that the subtitle (h2) on the HerokuApp homepage matches the expected text.
        /// 
        /// Arrange: Define the expected subtitle and navigate to the homepage.
        /// Act: Locate the subtitle element and retrieve its text.
        /// Assert: Compare the actual text to the expected subtitle.
        /// </summary>
        [TestMethod]
        public void SubTitleisOK()
        {
            var expectedSubtitle = "Available Examples";

            using (ChromeDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
                IWebElement subtitleElement = driver.FindElement(By.TagName("h2"));
                var actualSubtitle = subtitleElement.Text;

                Assert.AreEqual(expectedSubtitle, actualSubtitle);
            }
        }

        /// <summary>
        /// Verifies that the homepage contains exactly 44 example links listed as <li> elements.
        /// 
        /// Arrange: Navigate to the HerokuApp homepage.
        /// Act: Count the total number of list items in the unordered list.
        /// Assert: Ensure the count equals 44.
        /// </summary>
        [TestMethod]
        public void ExamplesCountis44()
        {
            // Arrange
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Optional: wait for the list to be present
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElements(By.CssSelector("ul li")).Count > 0);

            // Act
            IList<IWebElement> items = driver.FindElements(By.CssSelector("ul li"));
            int count = items.Count;

            // Assert
            Assert.AreEqual(44, count);


            // Cleanup
            driver.Quit();
        }



        [TestMethod]

        public void TenthExampleIsOkUsingXPATH()
        {
            var expectedText = "Drag and Drop";

            // Arrange
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Act
            // Use XPath to get the 10th <a> tag inside the <ul> list
            var actualText = driver.FindElement(By.XPath("(//ul/li/a)[10]")).Text;

            // Assert
            Assert.AreEqual(expectedText, actualText);

            // Cleanup
            driver.Quit();



        }
    }
}
