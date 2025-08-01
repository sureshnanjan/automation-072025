using HerokuOperations;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuAppWeb
{
    public class StatusCodesClassApp : IStatusCodes
    {
        public readonly IWebDriver driver;

        //Locators for elements on the Status Codes page
        public readonly By titleLocator = By.TagName("h3");
        public readonly By descriptionLocator = By.CssSelector(".example p");
        public readonly By statusCodeLinkLocator = By.XPath("//a[contains(@href, '/status_codes/')]");
        public readonly By statusMessageLocator = By.CssSelector(".example p");

        public StatusCodesClassApp(IWebDriver webDriver)
        {
            driver = webDriver;
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/status_codes");
        }



        public string GetPageTitle()
        {
            return driver.FindElement(titleLocator).Text;
        }

        public string GetDescriptionText()
        {
            return driver.FindElement(descriptionLocator).Text;
        }

        public void ClickStatusCode(string code)
        {
            driver.FindElement(By.LinkText(code)).Click();
        }

        public string GetStatusMessage()
        {
            return driver.FindElement(statusMessageLocator).Text;
        }


    }
}
