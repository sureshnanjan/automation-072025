using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;

namespace HerokuAppScenarios
{
    [TestFixture]
    public class RedirectScenarios
    {
        private IWebDriver _driver;
        private Redirect _redirect;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless"); // Run headless (no UI)
            options.AddArgument("--disable-gpu");
            options.AddArgument("--window-size=1920,1080");

            _driver = new ChromeDriver(options);
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/redirector");
            _redirect = new Redirect(_driver);
        }

        [Test]
        public void GetTitle_ShouldReturnCorrectText()
        {
            string title = _redirect.GetTitle();
            Assert.That(title, Is.EqualTo("Redirection"));
        }

        [Test]        
        public void GetParagraphText_ShouldContainExpectedMessage()
        {
            string paragraph = _redirect.GetParagraphText();
            StringAssert.Contains("redirect", paragraph); // keyword match
        }

        [Test]
        public void ClickhereLink_ShouldRedirectToStatusCodesPage()
        {
            _redirect.ClickhereLink();
            Assert.That(_driver.Url, Does.Contain("/status_codes"));
        }

        [TearDown]
        public void Teardown()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
        }
    }
}


/*
 Type of Testcases to be written
1 . GetTitle() - heading (Redirect link)
2. GetContent() - get the content of the  page
3. GetLogo() - if logo present or not .
4.ClickHere() - link to redirect to next page.
  4.1 Clickhere() - should redirect to the next page
  4.2 GetTitleStatusCode() - title of status code
  4.3 GetContentStatusCode() - paragraph 
  4.4 Get200() - redirect to 200 content page


 * \
