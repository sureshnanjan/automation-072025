<<<<<<< HEAD
﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

using OpenQA.Selenium.Firefox;

namespace HerokuAppTests
{
    // This class contains automated UI tests for the homepage of the-internet.herokuapp.com
    [TestClass]
    public sealed class HomePageTests
    {
        [TestInitialize]


        public void Init()
        {

        }

        [TestMethod]
        public void TitleisOK()
        {
            // This test verifies that the main heading (h1) on the homepage is "Welcome to the-internet"

            var expectedTitle = "Welcome to the-internet";

            // Launch Chrome browser and navigate to the site
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Locate the main heading element (h1)

        public void Init() {
            // Read from app.config
            //AppContext appContext = Confi
           
        }
        [TestMethod]
        public void TitleisOK()
        {
            // Arrange
            var expectedTitle = "Welcome to the-internet1";
            // Launch the browser and navigae to 
            ISearchContext driver = new ChromeDriver();
            driver = new FirefoxDriver();
            ((IWebDriver)driver).Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            IWebElement pageheading = driver.FindElement(By.TagName("h1"));

            // Act - get the actual heading text
            var actualTitle = pageheading.Text;

            // Assert - check if the actual heading matches the expected heading
            Assert.AreEqual(expectedTitle, actualTitle);

            // Cleanup - close the browser
            driver.Quit();
        }

        [TestMethod]
        public void SubTitleisOK()
        {
            // This test verifies that the subtitle (h2) on the homepage is "Available Examples"

            // Arrange - expected subtitle
            var expectedSubTitle = "Available Examples";

            // Launch Chrome browser and navigate to the site
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Locate the subtitle element in a "h2"
            IWebElement pageheading = driver.FindElement(By.TagName("h2"));

            // Act - get the actual subtitle text
            var actualSubTitle = pageheading.Text;

            // Assert - check if the actual subtitle matches the expected subtitle
            Assert.AreEqual(expectedSubTitle, actualSubTitle);

            // Cleanup - close the browser
            driver.Quit();
        }

        [TestMethod]
        public void ExamplesCountis44()
        {
            // This test verifies that the number of example links on the homepage is 44

            // Arrange - expected number of list items (each example is in a <li>)
            int expectedCount = 44;

            // Launch Chrome browser and navigate to the site
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Link is given in a list tag, so I am using tagname as "li"
            var listItems = driver.FindElements
                
                    (By.TagName("li"));

            // Act - count how many list items are found
            int actualCount = listItems.Count;

            // Assert - check if the actual count matches the expected count
            Assert.AreEqual(expectedCount, actualCount);

            // Cleanup - close the browser
            driver.Quit();
        }

        [TestMethod]
        public void TenthExampleisOkUsingID()
        {
            // Arrange
            var expectedText = "Drag and Drop";

            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            // Act
            var content = driver.FindElement(By.Id("content"));  // Find parent by ID
            var links = content.FindElements(By.TagName("a"));   // Get all <a> tags inside
            var actualText = links[9].Text;  // 10th link (index 9)

            // Assert
            Assert.AreEqual(expectedText, actualText);
=======
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
>>>>>>> f6bb7fb812dedd6e4734d3837588df55f2851795

            // Cleanup
            driver.Quit();
        }

<<<<<<< HEAD

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
=======
        /// <summary>
        /// Verifies that the 10th item in the example list is "Drag and Drop".
        /// 
        /// Arrange: Navigate to the HerokuApp homepage and wait for the list to load.
        /// Act: Retrieve the text of the 10th list item (zero-based index).
        /// Assert: Confirm the text matches "Drag and Drop".
        /// </summary>
        [TestMethod]
        public void TenthItemIsDragAndDrop()
        {
            // Arrange
            using (var driver = new ChromeDriver())
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.FindElements(By.CssSelector("ul li")).Count >= 10);

                // Act
                IList<IWebElement> items = driver.FindElements(By.CssSelector("ul li"));
                string tenthItemText = items[9].Text; // Index 9 = 10th item

                // Assert
                Assert.AreEqual("Drag and Drop", tenthItemText);
            }
>>>>>>> f6bb7fb812dedd6e4734d3837588df55f2851795
        }
    }
}
