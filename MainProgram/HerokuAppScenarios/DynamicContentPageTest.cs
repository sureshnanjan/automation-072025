using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;
using System;
using HerokuAppWeb;

namespace HerokuAppScenarios
{
    public class DynamicContentPageTest
    {
        private ChromeDriver driver; // Changed type from IWebDriver to ChromeDriver for CA1859

        private IDynamicContentPage dynamicContentPage;

        [SetUp]
        public void Setup()
        {

            //var options = new ChromeOptions();
            //options.AddArgument("--headless"); // Run in headless mode
            //options.AddArgument("--disable-gpu"); // Disable GPU hardware acceleration

            //driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dynamic_content");
            //dynamicContentPage = new DynamicContentPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null) // Ensure proper disposal for NUnit1032
            {
                driver.Dispose();
            }
        }

        [Test]
        public void ShouldReturnCorrectTitle()
        {
            string title = dynamicContentPage.GetTitle();
            Assert.AreEqual("Dynamic Content", title);
        }

        [Test]
        public void ShouldReturnNonEmptySubTitle()
        {
            string subtitle = dynamicContentPage.GetSubTitle();
            Assert.IsNotNull(subtitle);
            Assert.IsNotEmpty(subtitle);
        }

        [Test]
        public void ShouldReturnThreeContentRows()
        {
            int rowCount = dynamicContentPage.GetRowCount();
            Assert.AreEqual(3, rowCount);
        }

        [Test]
        public void EachRow_ShouldHaveText_AndImage()
        {
            int rowCount = dynamicContentPage.GetRowCount();
            for (int i = 0; i < rowCount; i++)
            {
                string text = dynamicContentPage.GetTextFromRow(i);
                string imageSrc = dynamicContentPage.GetImageSourceFromRow(i);

                Assert.IsNotNull(text, $"Row {i} text is null");
                Assert.IsNotEmpty(text, $"Row {i} text is empty");

                Assert.IsNotNull(imageSrc, $"Row {i} image src is null");
                Assert.IsTrue(imageSrc.StartsWith("http"), $"Row {i} image src is not a valid URL");
            }
        }

        [Test]
        public void InvalidRowIndex_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => dynamicContentPage.GetTextFromRow(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => dynamicContentPage.GetImageSourceFromRow(999));
        }
    }
}

