using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HerokuOperations.PageInterfaces;
using OpenQA.Selenium;

namespace HerokuOperations.PageClassApps
{
    public class CheckBoxesClassApp : ICheckBoxes
    {
        private readonly IWebDriver driver;

        public CheckBoxesClassApp(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void CheckFirstBox()
        {
            var firstCheckbox = driver.FindElement(By.XPath("//input[1]"));
            if (!firstCheckbox.Selected)
            {
                firstCheckbox.Click();
            }
        }

        public void UncheckSecondBox()
        {
            var secondCheckbox = driver.FindElement(By.XPath("//input[2]"));
            if (secondCheckbox.Selected)
            {
                secondCheckbox.Click();
            }
        }

        public bool IsFirstBoxChecked()
        {
            var firstCheckbox = driver.FindElement(By.XPath("//input[1]"));
            return firstCheckbox.Selected;
        }

        public bool IsSecondBoxChecked()
        {
            var secondCheckbox = driver.FindElement(By.XPath("//input[2]"));
            return secondCheckbox.Selected;
        }

        public List<bool> GetAllCheckboxStates()
        {
            var firstCheckbox = driver.FindElement(By.XPath("//input[1]"));
            var secondCheckbox = driver.FindElement(By.XPath("//input[2]"));
            return new List<bool>
            {
                firstCheckbox.Selected,
                secondCheckbox.Selected
            };
        }


    }
}
