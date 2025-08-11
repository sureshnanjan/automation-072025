using System;
using OpenQA.Selenium;
using HerokuOperations;

namespace HerokuTests
{
    /// <summary>
    /// Implementation of Shadow DOM operations for https://the-internet.herokuapp.com/shadowdom.
    /// Uses JavaScript to access shadow roots.
    /// </summary>
    /// <remarks>
    /// © 2025 Varun Kumar Reddy D. All rights reserved.
    /// </remarks>
    public class ShadowDOMPage : IShadowDOM
    {
        private readonly IWebDriver _driver;
        private readonly IJavaScriptExecutor _jsExecutor;

        public ShadowDOMPage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _jsExecutor = (IJavaScriptExecutor)_driver;
        }

        public string GetFirstShadowHostText()
        {
            // JavaScript to get first shadow host text
            string script = @"
                const host = document.querySelector('my-paragraph');
                return host.shadowRoot.querySelector('p').textContent;";
            return (string)_jsExecutor.ExecuteScript(script);
        }

        public string GetSecondShadowHostText()
        {
            // JavaScript to get second shadow host text
            string script = @"
                const hosts = document.querySelectorAll('my-paragraph');
                return hosts[1].shadowRoot.querySelector('p').textContent;";
            return (string)_jsExecutor.ExecuteScript(script);
        }

        public string GetNestedShadowText()
        {
            // JavaScript to access deeply nested shadow DOM text
            string script = @"
                const nested = document
                    .querySelector('my-paragraph')
                    .shadowRoot
                    .querySelector('ul > li');
                return nested.textContent;";
            return (string)_jsExecutor.ExecuteScript(script);
        }
    }
}
