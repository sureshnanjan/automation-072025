using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;
using HerokuOperations.Classes;
using System;

namespace HerokuAppScenarios
{
    public class DropdownPageAsDynamicContentTest
    {
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        private IWebDriver driver;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        private IDynamicContentPage dropdownPage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dropdown");
            dropdownPage = new DropdownPageAsDynamicContent(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void ShouldReturnCorrectTitle()
        {
            string title = dropdownPage.GetTitle();
            Assert.AreEqual("Dropdown List", title);
        }

        [Test]
        public void ShouldReturnSubtitleOrFallback()
        {
            string subtitle = dropdownPage.GetSubTitle();
            Assert.IsNotNull(subtitle);
        }

        [Test]
        public void ShouldReturnOptionCountGreaterThanOne()
        {
            int count = dropdownPage.GetRowCount();
            Assert.Greater(count, 1, "Expected at least 2 options (including placeholder)");
        }

        [Test]
        public void ShouldGetTextFromEachOption()
        {
            int count = dropdownPage.GetRowCount();
            for (int i = 0; i < count; i++)
            {
                string text = dropdownPage.GetTextFromRow(i);
                Assert.IsNotNull(text, $"Option {i} text is null");
                Assert.IsNotEmpty(text, $"Option {i} text is empty");
            }
        }

        [Test]
        public void GetImageSource_ShouldReturnNA()
        {
            string result = dropdownPage.GetImageSourceFromRow(0);
            Assert.AreEqual("N/A - No images on this page", result);
        }

        [Test]
        public void InvalidIndex_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => dropdownPage.GetTextFromRow(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => dropdownPage.GetTextFromRow(999));
        }
    }
}

