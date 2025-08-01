using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace HerokuOperations
{
    public class HorizontalSliderImplementation : IHorizontalSlider
    {
        private readonly IWebDriver _driver;

        public HorizontalSliderImplementation(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetTitle()
        {
            return _driver.FindElement(By.TagName("h3")).Text;
        }

        public string GetDescription()
        {
            return _driver.FindElement(By.ClassName("subheader")).Text;
        }

        public void FocusSlider()
        {
            var slider = _driver.FindElement(By.TagName("input"));
            slider.Click();
        }

        public int MoveSLiderLeft(int steps)
        {
            var slider = _driver.FindElement(By.TagName("input"));
            slider.Click();

            Actions actions = new Actions(_driver);
            for (int i = 0; i < steps; i++)
            {
                actions.SendKeys(Keys.ArrowLeft).Perform();
            }

            return GetSliderValue();
        }

        public int MoveSLiderRight(int steps)
        {
            var slider = _driver.FindElement(By.TagName("input"));
            slider.Click();

            Actions actions = new Actions(_driver);
            for (int i = 0; i < steps; i++)
            {
                actions.SendKeys(Keys.ArrowRight).Perform();
            }

            return GetSliderValue();
        }

        public int GetSliderValue()
        {
            var value = _driver.FindElement(By.Id("range")).Text;
            return (int)Convert.ToDouble(value); // Slider returns float like 2.5, round to int
        }
    }
}
