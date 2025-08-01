using HerokuOperations.PageInterface;
using HerokuOperations.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HerokuTests
{
    [TestFixture]
    public class ABTestTests
    {
        private IWebDriver _driver;
        private IABTest _abTestPage;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/abtest");

            _abTestPage = new ABTestPage(_driver); // Assigning your page object correctly
        }

        [TearDown]
        public void TearDown()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose(); // Dispose to satisfy NUnit analyzer
            }
        }

        [Test]
        public void GetTitle_ShouldReturnNonEmptyTitle()
        {
            string title = _abTestPage.GetTitle();
            Assert.IsNotNull(title);
            Assert.IsNotEmpty(title);
        }

        [Test]
        public void GetDescription_ShouldReturnValidText()
        {
            string description = _abTestPage.GetDescription();
            Assert.IsNotNull(description);
            Assert.IsTrue(description.Length > 10);
        }
    }
}
