using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace HerokuOperations.Pages
{
    public class Disappear : Idisappear
    {
        private readonly IWebDriver _driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisappearingElementsPage"/> class.
        /// </summary>
        /// <param name="driver">The Selenium WebDriver instance.</param>
        public Disappear(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <inheritdoc/>
        public string GetTitle()
        {
            return _driver.FindElement(By.TagName("h3")).Text;
        }

        /// <inheritdoc/>
        public string GetSubTitle()
        {
            return _driver.FindElement(By.ClassName("example")).FindElement(By.TagName("p")).Text;
        }

        /// <inheritdoc/>
        public string GetRepoUrl()
        {
            // No GitHub repo link is provided on this page.
            return string.Empty;
        }

        /// <inheritdoc/>
        public string[] GetVisibleNavigationItems()
        {
            IReadOnlyCollection<IWebElement> navElements = _driver.FindElements(By.CssSelector("ul li a"));
            return navElements.Select(element => element.Text.Trim()).ToArray();
        }
    }
}
