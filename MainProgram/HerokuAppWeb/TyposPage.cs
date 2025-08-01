// --------------------------------------------------------------------------------------
// Copyright (c) 2025 Arpita Neogi
// Date: August 1, 2025
//
// Licensed under the MIT License.
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// --------------------------------------------------------------------------------------

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace HerokuOperations
{
    /// <summary>
    /// Implementation of ITyposPage interface for interacting with the Typos page
    /// on https://the-internet.herokuapp.com/typos
    /// </summary>
    public class TyposPage : ITyposPage
    {
        private readonly IWebDriver _driver;
        private readonly string _baseUrl = "https://the-internet.herokuapp.com/typos";

        /// <summary>
        /// Constructor to initialize WebDriver instance.
        /// </summary>
        /// <param name="driver">Selenium WebDriver instance</param>
        public TyposPage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        /// <summary>
        /// Navigates to the Typos page.
        /// </summary>
        public void NavigateToPage()
        {
            _driver.Navigate().GoToUrl(_baseUrl);
        }

        /// <summary>
        /// Gets the page title after successful navigation.
        /// </summary>
        /// <returns>Page title as string.</returns>
        public string GetPageTitle()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.TagName("h3")));
            return _driver.FindElement(By.TagName("h3")).Text;
        }

        /// <summary>
        /// Gets the description text displayed on the Typos page.
        /// </summary>
        /// <returns>Page description as string.</returns>
        public string GetPageDescription()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.CssSelector("div.example p")));
            var paragraphs = _driver.FindElements(By.CssSelector("div.example p"));

            string descriptionText = string.Empty;
            foreach (var para in paragraphs)
            {
                descriptionText += para.Text + " ";
            }
            return descriptionText.Trim();
        }

        /// <summary>
        /// Checks if there are any typos on the page.
        /// This sample check assumes that the word 'won't' is misspelled sometimes as 'won,t'.
        /// </summary>
        /// <returns>True if typo is found, otherwise false.</returns>
        public bool HasTypos()
        {
            string pageText = GetPageDescription();

            // Example typo check (common intentional typo on this page)
            return pageText.Contains("won,t");
        }
    }
}
