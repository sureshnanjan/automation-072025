// -----------------------------------------------------------------------
// <copyright>
//     Copyright (c) 2025 K Vamsi Krishna. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HerokuOperations;
using OpenQA.Selenium;

namespace HerokuAppWeb
{
    /// <summary>
    /// Provides methods to interact with the shifting content menu links.
    /// </summary>
    public class ShiftingContentPage : IShiftingContentPage
    {
        private readonly IWebDriver driver;
        private readonly By titleLocator = By.TagName("h3");
        private readonly By descriptionLocator = By.TagName("p");
        private readonly By linksLocator = By.CssSelector("div.example a");

        public ShiftingContentPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/shifting_content/menu");
        }

        public string GetTitle()
        {
            return driver.FindElement(titleLocator).Text;
        }

        public string GetDescription()
        {
            return driver.FindElement(descriptionLocator).Text;
        }

        public int GetLinkCount()
        {
            return driver.FindElements(linksLocator).Count;
        }

        public string[] GetAllLinkTexts()
        {
            var links = driver.FindElements(linksLocator);
            string[] linkTexts = new string[links.Count];
            for (int i = 0; i < links.Count; i++)
            {
                linkTexts[i] = links[i].Text;
            }
            return linkTexts;
        }
    }
}
