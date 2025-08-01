using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using HerokuOperations;

namespace HerokuOperationsTests
{
    [TestFixture]
    public class ABTestPageTests
    {
        private IWebDriver _driver;
        private ABTestPage _abTestPage;

        [SetUp]
        public void Setup()
        {
            // Initialize ChromeDriver
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");
            // chromeOptions.AddArgument("--headless"); // Optional: run in headless mode

            _driver = new ChromeDriver(chromeOptions);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // Create instance of ABTestPage
            _abTestPage = new ABTestPage(_driver);
        }

        [Test]
        public void GetTitle_ShouldReturnABTestingTitle()
        {
            // Act
            string title = _abTestPage.GetTitle();

            // Assert
            Assert.That(title, Is.EqualTo("A/B Test Variation 1").Or.EqualTo("A/B Test Control"),
                "Page title should match one of the A/B Testing variants.");
        }

        [Test]
        public void GetDescription_ShouldReturnValidDescription()
        {
            // Act
            string description = _abTestPage.GetDescription();

            // Assert
            Assert.That(description, Is.Not.Null.And.Not.Empty,
                "Description text should not be empty.");
        }

        [Test]
        public void DisableABTest_ShouldNavigateToOptOutVersion()
        {
            // Act
            _abTestPage.DisableABTest();

            // Assert
            Assert.That(_driver.Url, Does.Contain("optout=true"),
                "URL should indicate A/B test is disabled.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}
