using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace HerokuOperations
{
    public class HoverImplementation : IHoverProfile
    {
        private readonly IWebDriver _driver;

        public HoverImplementation(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetTitle()
        {
            return _driver.FindElement(By.TagName("h3")).Text;
        }

        public string Description()
        {
            return _driver.FindElement(By.ClassName("subheader")).Text;
        }

        public int GetProfileCount()
        {
            return _driver.FindElements(By.ClassName("figure")).Count;
        }

        public void HoverOverProfileImage(int index)
        {
            var profiles = _driver.FindElements(By.ClassName("figure"));
            if (index >= 0 && index < profiles.Count)
            {
                Actions actions = new Actions(_driver);
                actions.MoveToElement(profiles[index]).Perform();
            }
        }

        public bool IsProfileInfoDisplayed(int index)
        {
            HoverOverProfileImage(index);
            var captions = _driver.FindElements(By.ClassName("figcaption"));
            return captions[index].Displayed;
        }

        public string GetProfileName(int index)
        {
            HoverOverProfileImage(index);
            return _driver.FindElements(By.ClassName("figcaption"))[index].FindElement(By.TagName("h5")).Text;
        }

        public string GetProfileLink(int index)
        {
            HoverOverProfileImage(index);
            return _driver.FindElements(By.ClassName("figcaption"))[index].FindElement(By.TagName("a")).GetAttribute("href");
        }
    }
}
