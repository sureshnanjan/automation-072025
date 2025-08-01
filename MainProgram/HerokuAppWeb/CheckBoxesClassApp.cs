using System.Collections.Generic;
using OpenQA.Selenium;
using HerokuOperations;

namespace HerokuAppWeb
{
    public class CheckBoxesClassApp : ICheckBoxes
    {
        private readonly IWebDriver driver;

        //locators
        private readonly By titleLocator = By.TagName("h3");
        private readonly By firstCheckboxLocator = By.XPath("//input[1]");
        private readonly By secondCheckboxLocator = By.XPath("//input[2]");

        public CheckBoxesClassApp(IWebDriver webDriver)
        {
            driver = webDriver;
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/checkboxes");
        }

        public string GetPageTitle()
        {
            return driver.FindElement(titleLocator).Text;
        }

        public void CheckFirstBox()
        {
            var firstCheckbox = driver.FindElement(firstCheckboxLocator);
            if (!firstCheckbox.Selected)
            {
                firstCheckbox.Click();
            }
        }

        public void UncheckSecondBox()
        {
            var secondCheckbox = driver.FindElement(secondCheckboxLocator);
            if (secondCheckbox.Selected)
            {
                secondCheckbox.Click();
            }
        }

        public bool IsFirstBoxChecked()
        {
            return driver.FindElement(firstCheckboxLocator).Selected;
        }

        public bool IsSecondBoxChecked()
        {
            return driver.FindElement(secondCheckboxLocator).Selected;
        }

        public List<bool> GetAllCheckboxStates()
        {
            return new List<bool>
            {
                IsFirstBoxChecked(),
                IsSecondBoxChecked()
            };
        }
    }
}
