// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShadowDomHandler.cs" company="Keyur Nagvekar">
//   Copyright (c) 2025 Keyur Nagvekar. All rights reserved.
//   This file provides an implementation for accessing and retrieving Shadow DOM elements
//   using JavaScript execution with Selenium, based on the ShadowDOM interface.
//   Redistribution or modification of this file is subject to author permissions.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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
            catch
            {
                return string.Empty;
            }
        }

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
            catch
            {
                return string.Empty;
            }
        }

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
            catch
            {
                return string.Empty;
            }
        }
    }
}
