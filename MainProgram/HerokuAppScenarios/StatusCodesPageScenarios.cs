using HerokuOperations;
using HerokuAppWeb;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HerokuAppScenarios
{
    public class StatusCodesPageScenarios
    {
        private IWebDriver driver;
        private IStatusCodes statusCodesPage;

        [SetUp]
        public void Setup()
        {
 
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void PageTitleAndDescription_AreCorrect()
        {
            string title = statusCodesPage.GetPageTitle();
            string description = statusCodesPage.GetDescriptionText();

            Assert.AreEqual("Status Codes", title);
            Assert.IsTrue(description.Contains("HTTP status codes are a standard set of numbers used to communicate from a web server to your browser to indicate the outcome of the request being made (e.g. Success, Redirection, Client Error, Server Error). For a complete list of status codes, go here."));
        }

        [TestCase("200", "This page returned a 200 status code.")]
        [TestCase("301", "This page returned a 301 status code.")]
        [TestCase("404", "This page returned a 404 status code.")]
        [TestCase("500", "This page returned a 500 status code.")]
        public void ClickStatusCode_DisplaysCorrectMessage(string code, string expectedMessage)
        {
            statusCodesPage.ClickStatusCode(code);
            string message = statusCodesPage.GetStatusMessage();
            Assert.IsTrue(message.Contains(expectedMessage));
        }
    }
}
