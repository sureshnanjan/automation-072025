using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using HerokuOperations;
namespace HerokuAppWeb
{
    /// <summary>
    /// Implements the IForgotPassword interface for interacting with the
    /// Forgot Password page on the Heroku web application.
    /// </summary>
    internal class ForgotPassword : IForgotPassword
    {
        private readonly IWebDriver _driver;

        // Locators
        private readonly By _titleLocator = By.TagName("h2");
        private readonly By _emailInputLocator = By.Id("email");
        private readonly By _retrieveButtonLocator = By.Id("form_submit");
        private readonly By _confirmationMessageLocator = By.Id("content");

        public ForgotPassword(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetTitle()
        {
            return _driver.FindElement(_titleLocator).Text;
        }

        public void EnterEmail(string email)
        {
            var emailField = _driver.FindElement(_emailInputLocator);
            emailField.Clear();
            emailField.SendKeys(email);
        }

        public void ClickRetrievePassword()
        {
            _driver.FindElement(_retrieveButtonLocator).Click();
        }

        public string GetConfirmationMessage()
        {
            return _driver.FindElement(_confirmationMessageLocator).Text;
        }
    }
}
