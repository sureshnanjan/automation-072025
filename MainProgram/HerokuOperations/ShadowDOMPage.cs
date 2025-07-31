using OpenQA.Selenium;

namespace HerokuOperations
{
    public class ShadowDOMPage : IShadowDOM
    {
        private readonly IWebDriver _driver;

        public ShadowDOMPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetFirstShadowHostText()
        {
            var shadowHost = _driver.FindElement(By.CssSelector("css-selector-for-first-shadow-host"));
            var shadowRoot = (IWebElement)((IJavaScriptExecutor)_driver).ExecuteScript("return arguments[0].shadowRoot", shadowHost);
            return shadowRoot.FindElement(By.CssSelector("css-selector-for-element")).Text;
        }

        public string GetSecondShadowHostText()
        {
            var shadowHost = _driver.FindElement(By.CssSelector("css-selector-for-second-shadow-host"));
            var shadowRoot = (IWebElement)((IJavaScriptExecutor)_driver).ExecuteScript("return arguments[0].shadowRoot", shadowHost);
            return shadowRoot.FindElement(By.CssSelector("css-selector-for-element")).Text;
        }

        public string GetNestedShadowText()
        {
            var shadowHost = _driver.FindElement(By.CssSelector("css-selector-for-nested-shadow-host"));
            var shadowRoot = (IWebElement)((IJavaScriptExecutor)_driver).ExecuteScript("return arguments[0].shadowRoot", shadowHost);
            var nestedShadowHost = shadowRoot.FindElement(By.CssSelector("css-selector-for-nested-shadow-host"));
            var nestedShadowRoot = (IWebElement)((IJavaScriptExecutor)_driver).ExecuteScript("return arguments[0].shadowRoot", nestedShadowHost);
            return nestedShadowRoot.FindElement(By.CssSelector("css-selector-for-element")).Text;
        }
    }
}
