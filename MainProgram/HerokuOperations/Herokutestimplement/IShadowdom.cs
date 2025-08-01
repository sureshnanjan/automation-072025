using OpenQA.Selenium;
using System;

namespace HerokuOperations
{
    /// <summary>
    /// Provides access to Shadow DOM elements using JavaScript execution.
    /// Implements the ShadowDOM interface.
    /// </summary>
    public class ShadowDomHandler : ShadowDOM
    {
        private readonly IWebDriver driver;
        private readonly IJavaScriptExecutor js;

        public ShadowDomHandler(IWebDriver webDriver)
        {
            driver = webDriver;
            js = (IJavaScriptExecutor)webDriver;
        }

        /// <summary>
        /// Gets the text content of the first shadow host's paragraph.
        /// Example: "My default text"
        /// </summary>
        public string GetFirstShadowHostText()
        {
            try
            {
                string script = @"
                    const shadowHost = document.querySelector('my-paragraph');
                    const shadowRoot = shadowHost.shadowRoot;
                    return shadowRoot.querySelector('p').textContent.trim();";
                return (string)js.ExecuteScript(script);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the text content of the second shadow host's span element.
        /// Example: "Let's have some different text!"
        /// </summary>
        public string GetSecondShadowHostText()
        {
            try
            {
                string script = @"
                    const shadowHost = document.querySelector('my-paragraph');
                    const shadowRoot = shadowHost.shadowRoot;
                    return shadowRoot.querySelector('span').textContent.trim();";
                return (string)js.ExecuteScript(script);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the text from a nested shadow DOM element if present.
        /// Adjust selectors inside JavaScript if nesting is deeper.
        /// </summary>
        public string GetNestedShadowText()
        {
            try
            {
                string script = @"
                    const outerHost = document.querySelector('my-paragraph');
                    const outerRoot = outerHost.shadowRoot;
                    const nested = outerRoot.querySelector('span');

                    return nested ? nested.textContent.trim() : '';";

                return (string)js.ExecuteScript(script);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
