using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;
using System;
using HerokuAppWeb;

namespace HerokuAppScenarios
{
    public class ShiftingContentPageTest
    {
        private ChromeDriver driver; // Changed type from IWebDriver to ChromeDriver for performance

        private IShiftingContentPage shiftingContentPage;

        [SetUp]
        public void Setup()
        {

            //var options = new ChromeOptions();
            //options.AddArgument("--headless"); // Run in headless mode
            //options.AddArgument("--disable-gpu"); // Disable GPU hardware acceleration

            //driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/shifting_content");
            //shiftingContentPage = new ShiftingContentPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose(); // Ensures proper disposal of the driver
        }

        [Test]
        public void ShouldReturnCorrectTitle()
        {
            string title = shiftingContentPage.GetTitle();
            Assert.AreEqual("Shifting Content", title);
        }

        [Test]
        public void ShouldReturnNonEmptyDescription()
        {
            string description = shiftingContentPage.GetDescription();
            Assert.IsNotNull(description);
            Assert.IsNotEmpty(description);
        }

        [Test]
        public void ShouldReturnAtLeastOneLink()
        {
            int linkCount = shiftingContentPage.GetLinkCount();
            Assert.Greater(linkCount, 0);
        }

        [Test]
        public void ShouldReturnLinkTextsMatchingCount()
        {
            string[] links = shiftingContentPage.GetAllLinkTexts();
            int count = shiftingContentPage.GetLinkCount();

            Assert.AreEqual(count, links.Length);
            foreach (string linkText in links)
            {
                Assert.IsNotNull(linkText);
                Assert.IsNotEmpty(linkText);
            }
        }
    }
}

